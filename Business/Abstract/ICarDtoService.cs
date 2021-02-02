using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarDtoService
    {
        CarPto GetById(int id);
        List<CarPto> GetAll();
    }
}
