using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlDbContext>, ICarDal
    {
        public CarPto GetCarDetail(Car car)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {

                return new CarPto { };

                //var result = from c in cars
                //        join b in dbContext.Brand on c.BrandId equals b.BrandId
                //        join m in dbContext.Model on c.ModelId equals m.ModelId
                //        join col in dbContext.Color on c.ColorId equals col.ColorId
                //        select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

                //return result;
            }
        }
    }
}
