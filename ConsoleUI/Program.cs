using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());

            CarManager carManager = new CarManager(new InMemoryCarDal(),brandManager);

            foreach(Car car in carManager.GetAll()) {
                Console.WriteLine(brandManager.GetById(car.BrandId).BrandName+"  " +brandManager.GetById(car.BrandId).ModelId);
                
            }

            carManager.Delete(new Car() { Id = 1, BrandId = 5, ColorId = "Beyaz", ModelYear = "2005", DailyPrice = 55000, Description = "Sahibinden temiz focus" });
            Console.WriteLine("--------------Kayıt Silindi---------------");

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine(brandManager.GetById(car.BrandId).BrandName + "   " + car.DailyPrice);

            }
        }
    }
}
