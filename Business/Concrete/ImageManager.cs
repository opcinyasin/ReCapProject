using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Add(ImageDto item)
        {

            foreach (var file in item.Files)
            {
                if (BusinessRules.Run(CheckImageLimitExceeded(item.CarId)) != null)
                {
                    return new ErrorResult();
                }

                var result = FileHelper.add(file);
                if (!result.Success)
                {
                    return result;
                }
                _imageDal.Add(new Image { CarId = item.CarId, ImagePath = result.Message, DateTime = DateTime.Now });

            }

            return new SuccessResult();
        }

        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Update(ImageDto item)
        {
            var getResult = _imageDal.Get(i => i.Id == item.Id);
            var deleteResult = FileHelper.Delete(getResult.ImagePath);

            if (!deleteResult.Success)
            {
                return deleteResult;
            }
            if (BusinessRules.Run(CheckImageLimitExceeded(item.CarId)) != null)
            {
                return new ErrorResult();
            }

            var fileResult = FileHelper.add(item.Files[0]);
            if (!fileResult.Success)
            {
                return fileResult;
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(ImagesValidator))]
        public IResult Delete(ImageDto item)
        {

            var getResult = _imageDal.Get(i => i.Id == item.Id);

            _imageDal.Delete(new Image { Id = item.Id, CarId = item.CarId, ImagePath = item.ImagePath });

            var deleteResult = FileHelper.Delete(getResult.ImagePath);


            return deleteResult;
        }

        public IDataResult<List<Image>> GetAllImage()
        {
            return new SuccessDataResult<List<Image>>(data: _imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetImageById(int id)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i => i.CarId == id));
        }


        private  IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _imageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private void CheckIfCarImageNull(int id)
        {
            string path = @"\images\logo.jpg";
            var result = _imageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                new Image { CarId = id, ImagePath = path, DateTime = DateTime.Now };
            }

        }

        public IDataResult<List<ImageDto>> GetAll()
        {
            throw new Exception();
        }

        public IDataResult<List<ImageDto>> GetById(int id)
        {
            throw new Exception();
        }

    }
}
