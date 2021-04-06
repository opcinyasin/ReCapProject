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
        public CarDto GetCarDetailById(int id)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {

                var result = from c in dbContext.Car.Where(c=>c.Id==id).ToList()
                             join b in dbContext.Brand on c.BrandId equals b.BrandId
                             join m in dbContext.Model on c.ModelId equals m.ModelId
                             join col in dbContext.Color on c.ColorId equals col.ColorId
                             select new
                             CarDto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

                return result.SingleOrDefault(c=>c.Id==id);
            }
        }

     

        public List<CarDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {
                return filter == null ? this.GetCarsDetails() : GetFilterCarDetails(this.GetAll(filter));
            }
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
        private List<CarDto> GetFilterCarDetails(List<Car> cars)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {

                var result = from c in cars
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
