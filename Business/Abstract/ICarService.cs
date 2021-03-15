using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IService<Car>
    {

        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByModelId(int id);
        IDataResult<List<Car>> GetCarsByPrice(int min, int max);
        IDataResult<CarDto> GetCarDetailsById(int id);

    }
}
