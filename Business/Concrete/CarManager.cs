using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                return new SuccessResult("Aracınız eklendi");
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public CarPto GetCarDetailsById(int id)
        {
            return _carDal.GetCarDetailById(id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(b => b.ColorId == id);
        }

        public List<Car> GetCarsByModelId(int id)
        {
            return _carDal.GetAll(m => m.ModelId == id);
        }

        public List<Car> GetCarsByPrice(int min, int max)
        {
            return _carDal.GetAll(p => Convert.ToInt32(p.Price) >= min && Convert.ToInt32(p.Price) <= max);
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
                        return new Result(true);
                    }
                    else
                    {
                        return new ErrorResult("Model yılını kontrol ediniz.");
                    }


                }
                else
                {
                    return new ErrorResult("Aracın fiyatı 0 dan büyük olmalı");
                }

            }
            else
            {
                return new ErrorResult("Araç açıklaması 2 karakterden uzun olmalı.");
            }
        }
    }
}
