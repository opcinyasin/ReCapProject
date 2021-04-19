using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(CarValidator))]
        [PerformanceAspect(5)]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));

        }

        [CacheAspect]
        public IDataResult<CarDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDto>(_carDal.GetAllCarDetails(c=>c.Id==id).FirstOrDefault());
        }

        public IDataResult<List<CarDto>> GetAllCarsDetails()
        {
            Thread.Sleep(5);
            return new SuccessDataResult<List<CarDto>>(_carDal.GetAllCarDetails());
        }


        public IDataResult<List<CarDto>> GetCarsByBrandId(int id)
        {

            return new SuccessDataResult<List<CarDto>>(_carDal.GetAllCarDetails(c => c.BrandId == id));
        }

        public IDataResult<List<CarDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetAllCarDetails(b => b.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByModelId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(m => m.ModelId == id));
        }

        public IDataResult<List<Car>> GetCarsByPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => int.Parse(p.Price) >= min && int.Parse(p.Price) <= max));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

    }
}
