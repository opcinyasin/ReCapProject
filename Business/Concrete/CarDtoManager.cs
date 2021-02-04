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

        List<Car> _carList;
        IBrandService _brandService;
        IColorService _colorService;
        IModelService _modelService;

        public CarDtoManager(List<Car> carList, IBrandService brandService, IColorService colorService, IModelService modelService)
        {
            _carList = carList;
            _brandService = brandService;
            _colorService = colorService;
            _modelService = modelService;
        }

        public List<CarPto> GetAll()
        {
            var result =  from c in _carList
                                        join b in _brandService.GetAll() on c.BrandId equals b.BrandId
                                        join m in _modelService.GetAll() on c.ModelId equals m.ModelId
                                        join col in _colorService.GetAll() on c.ColorId equals col.ColorId
                                        select new CarPto { Id = c.Id, BrandName = b.BrandName, ModelName = m.ModelName, ColorName = col.ColorName, ModelYear = c.ModelYear, Price = c.Price, Description = c.Description };

            return result.ToList();
        }

    }
}
