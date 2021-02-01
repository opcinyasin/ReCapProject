using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            ModelManager modelManager = new ModelManager(new InMemoryModelDal());

            CarManager carManager = new CarManager(new InMemoryCarDal(),brandManager);


            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll() on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll() on b.ModelId equals m.ModelId
                         select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorId = c.ColorId, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };



            foreach (CarPto car in result) {

                Console.WriteLine($"{car.BrandName} {car.ModelName} araçın fiyatı {car.DailyPrice}");
            }

            
        }
    }
}
