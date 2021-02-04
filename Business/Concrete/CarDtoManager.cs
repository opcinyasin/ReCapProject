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

        ICarService _carService;
        IBrandService _brandService;
        IColorService _colorService;
        IModelService _modelService;

        public CarDtoManager(ICarService carService, IBrandService brandService, IColorService colorService, IModelService modelService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
            _modelService = modelService;
        }

        public List<CarPto> GetAll()
        {
            var result =  from c in _carService.GetAll()
                                        join b in _brandService.GetAll() on c.BrandId equals b.BrandId
                                        join m in _modelService.GetAll() on b.ModelId equals m.ModelId
                                        join col in _colorService.GetAll() on c.ColorId equals col.ColorId
                                        select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };

            return result.ToList();
        }

    }
}
