using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            var results = carManager.GetAll();

            if (results.Success)
            {
                foreach (var item in results.Data)
                {
                    var result = carManager.GetCarDetailsById(item.Id);
                    Console.WriteLine("{0} {1} aracın fiyatı: {2}", result.Data.BrandName, result.Data.ModelName, result.Data.Price);
                }
            }
            else Console.WriteLine(results.Message);
            

        }
    }
}
