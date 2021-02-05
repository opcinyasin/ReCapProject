﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
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

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            ModelManager modelManager = new ModelManager(new EfModelDal());

            ColorManager colorManager = new ColorManager(new EfColorDal());

            CarManager carManager = new CarManager(new EfCarDal());

            var carDtoManager = new CarDtoManager(carManager.GetCarsByPrice(160000,185000), brandManager, colorManager, modelManager);




            foreach (var item in carDtoManager.GetAll())
            {
                Console.WriteLine("{0} {1} aracın fiyatı {2} model yılı {3}", item.BrandName, item.ModelName, item.Price, item.ModelYear);
            }


        }
    }
}
