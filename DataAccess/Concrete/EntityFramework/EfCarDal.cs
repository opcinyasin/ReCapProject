using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SqlDbContext>, ICarDal
    {
        public CarPto GetCarDetailById(int id)
        {
            using (SqlDbContext dbContext = new SqlDbContext())
            {

                var result = from c in dbContext.Car.Where(c=>c.Id==id).ToList()
                             join b in dbContext.Brand on c.BrandId equals b.BrandId
                             join m in dbContext.Model on c.ModelId equals m.ModelId
                             join col in dbContext.Color on c.ColorId equals col.ColorId
                             select new
                             CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

                return result.SingleOrDefault(c=>c.Id==id);
            }
        }
    }
}
