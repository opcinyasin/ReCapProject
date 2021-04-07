using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            colorDal.Add(color);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Color color)
        {
            colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetById(int id)
        {

            return new SuccessDataResult<List<Color>>(colorDal.GetAll(c => c.ColorId == id));

        }

        public IResult Update(Color color)
        {
            colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
