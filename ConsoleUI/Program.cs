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

            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            CarManager carManager = new CarManager(new InMemoryCarDal(),brandManager);


            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll() on c.BrandId equals b.BrandId
                         join m in modelManager.GetAll() on b.ModelId equals m.ModelId
                         join col in colorManager.GetAll() on c.ColorId equals col.ColorId
                         select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };


            foreach (CarPto car in result) {

                Console.WriteLine($"{car.BrandName} {car.ModelName} aracın fiyatı {car.DailyPrice} ve rengi {car.ColorName}");
            }

            
        }
    }
}
