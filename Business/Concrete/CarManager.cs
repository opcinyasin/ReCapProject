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
        [SecuredOperation("admin")]
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

        public IDataResult<List<Car>> getById(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));

        }

        [CacheAspect]
        public IDataResult<CarPto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarPto>(_carDal.GetCarDetailById(id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByModelId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(m => m.ModelId == id));
        }

        public IDataResult<List<Car>> GetCarsByPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => Convert.ToInt32(p.Price) >= min && Convert.ToInt32(p.Price) <= max));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

    }
}
