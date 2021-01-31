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
                Console.WriteLine(brandManager.GetById(car.BrandId).BrandName);
            }
        }
    }
}
