using System;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarDto GetCarDetailById(int id);
        List<CarDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null);
    }
}
