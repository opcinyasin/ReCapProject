using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlDbContext>, ICarDal
    {

        public List<CarDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? this.GetCarsDetails() : GetFilterCarDetails(filter);
        }

        private List<CarDto> GetCarsDetails()
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {

                var result = from c in dbContext.Car
                    join b in dbContext.Brand on c.BrandId equals b.BrandId
                    join m in dbContext.Model on c.ModelId equals m.ModelId
                    join col in dbContext.Color on c.ColorId equals col.ColorId
                    select new
                        CarDto
                        { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

                return result.ToList();
            }
        }
        private List<CarDto> GetFilterCarDetails(Expression<Func<Car, bool>> filter)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {
                
                var result = from c in dbContext.Car.Where(filter)
                    join b in dbContext.Brand on c.BrandId equals b.BrandId
                    join m in dbContext.Model on c.ModelId equals m.ModelId
                    join col in dbContext.Color on c.ColorId equals col.ColorId
                    select new
                        CarDto
                        { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

                return result.ToList();
            }
        }
    }
}
