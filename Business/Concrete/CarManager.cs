using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Car car)
        {

            var result = Validation(car);

            if (result.Success)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return result;
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

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
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(b => b.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByModelId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(m => m.ModelId == id));
        }

        public IDataResult<List<Car>> GetCarsByPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => Convert.ToInt32(p.Price) >= min && Convert.ToInt32(p.Price) <= max));
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        private IResult Validation(Car car)
        {
            int carprice = Convert.ToInt32(car.Price);

            if (car.Description.Length >= 2)
            {
                if (carprice > 0)
                {
                    if (car.ModelYear.Length == 4)
                    {
                        return new SuccessResult();
                    }
                    else
                    {
                        return new ErrorResult(Messages.CarModelYearInvalid);
                    }


                }
                else
                {
                    return new ErrorResult(Messages.CarPriceInvalid);
                }

            }
            else
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }
        }
    }
}
