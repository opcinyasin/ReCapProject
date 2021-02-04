using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryBrandDal : IBrandDal
    {

        List<Brand> _brandsList;

        public InMemoryBrandDal()
        {
            _brandsList = new List<Brand> {
                new Brand{BrandId=1,BrandName="BMW"},
                new Brand{BrandId=2,BrandName="Audi"},
                new Brand{BrandId=3,BrandName="Opel"},
                new Brand{BrandId=4,BrandName="Fiat"},
                new Brand{BrandId=5,BrandName="Ford"}
            };
        }

        public void Add(Brand brand)
        {
            _brandsList.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand _brand = _brandsList.SingleOrDefault(b => brand.BrandId == b.BrandId);
            _brandsList.Remove(_brand);

        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brandsList;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int Id)
        {
            return _brandsList.SingleOrDefault(b => Id == b.BrandId);
        }

        public bool isBrandId(int Id)
        {
            return _brandsList.Where(b => b.BrandId == Id).Any();

            
        }

        public void Update(Brand brand)
        {
            Brand _brand = _brandsList.SingleOrDefault(b => brand.BrandId == b.BrandId);
            _brand.BrandName = brand.BrandName;
            
        }

      
    }
}
