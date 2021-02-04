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

            CarDtoManager carDtoManager = new CarDtoManager(carManager, brandManager, colorManager, modelManager);



            var result = carDtoManager.GetAll();


            foreach (CarPto car in result)
            {
                Console.WriteLine("-----------******************---------------");
                Console.WriteLine($"{car.BrandName} {car.ModelName} aracın fiyatı {car.DailyPrice} ve rengi {car.ColorName}");
            }


        }
    }
}
