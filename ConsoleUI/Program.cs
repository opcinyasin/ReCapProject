using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

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


            var result = carManager.GetCarDetailsById(8);


            Console.WriteLine("{0} {1} aracın fiyatı: {2}", result.BrandName, result.ModelName, result.Price);

        }
    }
}
