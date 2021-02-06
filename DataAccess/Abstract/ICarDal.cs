using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarPto GetCarDetail(Car car);
    }
}
