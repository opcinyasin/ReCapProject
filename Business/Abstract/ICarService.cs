using Core.Business;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IService<Car>
    {
        
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByModelId(int id);
        List<Car> GetCarsByPrice(int min,int max);
        CarPto GetCarDetailsById(int id);

    }
}
