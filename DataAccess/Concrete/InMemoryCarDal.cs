using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _carsList;

        public InMemoryCarDal()
        {
            _carsList = new List<Car> {
                new Car(){Id=1, BrandId=5, ColorId="Beyaz", ModelYear="2005", DailyPrice=55000, Description="Sahibinden temiz focus" },
                new Car(){Id=2, BrandId=3, ColorId="Siyah", ModelYear="2008", DailyPrice=80000, Description="Sahibinden temiz astra"},
                new Car(){Id=3, BrandId=2, ColorId="Kırmızı", ModelYear="2012", DailyPrice=125000, Description="Sahibinden temiz audi a5"}
            };
        }


        public void Add(Car car)
        {
            _carsList.Add(car);
        }

        public void Delete(Car car)
        {
            Car _car = _carsList.SingleOrDefault(c => car.Id == c.Id);
            _carsList.Remove(_car);
        }

        public List<Car> GetAll()
        {
            return _carsList;
        }

        public Car GetById(int id)
        {
            return (Car) _carsList.Where(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car _car = _carsList.SingleOrDefault(c => car.Id == c.Id);
            _car.BrandId = car.BrandId;
            _car.ColorId = car.ColorId;
            _car.ModelYear = car.ModelYear;
            _car.DailyPrice = car.DailyPrice;
            _car.Description = car.Description;
        }
    }
}
