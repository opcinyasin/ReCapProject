using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {
        IDataResult<List<CarDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDto>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByModelId(int id);
        IDataResult<List<Car>> GetCarsByPrice(int min, int max);
        IDataResult<CarDto> GetCarDetailsById(int id);
        IDataResult<List<CarDto>> GetAllCarsDetails();

    }
}
