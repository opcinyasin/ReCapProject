using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _carsList;

        public InMemoryCarDal()
        {
            _carsList = new List<Car> {
                new Car(){Id=1, BrandId=5, ColorId=3, ModelYear="2005", Price="55000", Description="Sahibinden temiz focus" },
                new Car(){Id=2, BrandId=3, ColorId=2, ModelYear="2008", Price="80000", Description="Sahibinden temiz astra"},
                new Car(){Id=3, BrandId=2, ColorId=4, ModelYear="2012", Price="125000", Description="Sahibinden temiz audi a5"}
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carsList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return (Car) _carsList.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car _car = _carsList.SingleOrDefault(c => car.Id == c.Id);
            _car.BrandId = car.BrandId;
            _car.ColorId = car.ColorId;
            _car.ModelYear = car.ModelYear;
            _car.Price = car.Price;
            _car.Description = car.Description;
        }
    }
}
