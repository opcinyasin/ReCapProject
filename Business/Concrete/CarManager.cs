using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        BrandManager _brandManager;

        public CarManager(ICarDal carDal, BrandManager brandManager)
        {
            _carDal = carDal;
            _brandManager = brandManager;
        }

        public void Add(Car car)
        {
            if (_brandManager.isBrandId(car.Id))
            {
                _carDal.Add(car);    
            }
            else
            {
                Console.WriteLine("Sistemimizde bu marka araç satışı yapılmamaktadır.");
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

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
