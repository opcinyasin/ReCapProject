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
    public class EfModelDal : IModelDal
    {
        public void Add(Model entity)
        {
            using (SqlDbContext dbContext =new SqlDbContext())
            {
                var addedModel = dbContext.Entry(entity);
                addedModel.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Model entity)
        {
            using (SqlDbContext context = new SqlDbContext())
            {
                var deletedModel = context.Entry(entity);
                deletedModel.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Model Get(Expression<Func<Model, bool>> filter)
        {
            using (SqlDbContext context = new SqlDbContext())
            {
                return  context.Set<Model>().SingleOrDefault(filter);
            }
        }

        public List<Model> GetAll(Expression<Func<Model, bool>> filter = null)
        {
            using (SqlDbContext context = new SqlDbContext())
            {
                return filter == null ? context.Set<Model>().ToList() : context.Set<Model>().Where(filter).ToList();
            }
        }

        public void Update(Model entity)
        {
            using (SqlDbContext context = new SqlDbContext())
            {
                var updatedModel = context.Entry(entity);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
