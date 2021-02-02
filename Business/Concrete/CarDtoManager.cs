using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarDtoManager : ICarDtoService
    {

        ICarService _carDal;
        IBrandService _brandDal;
        IColorDal _colorDal;
        IModelDal _modelDal;

        public CarDtoManager(ICarService carDal, IBrandService brandDal, IColorDal colorDal, IModelDal modelDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
            _modelDal = modelDal;
        }

        public List<CarPto> GetAll()
        {
            var result =  from c in _carDal.GetAll()
                                        join b in _brandDal.GetAll() on c.BrandId equals b.BrandId
                                        join m in _modelDal.GetAll() on b.ModelId equals m.ModelId
                                        join col in _colorDal.GetAll() on c.ColorId equals col.ColorId
                                        select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };

            return result.ToList();
        }

        public CarPto GetById(int id)
        {

            var c = _carDal.GetById(id);
            var b = _brandDal.GetById(c.BrandId);
            var m = _modelDal.GetById(b.ModelId);
            var col = _colorDal.GetById(c.ColorId);
            
            return new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
        }
    }
}
