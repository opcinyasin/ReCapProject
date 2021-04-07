using Core.Entities;
using Core.Utilities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IService<T> where T:class,IEntity,new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<List<T>> GetById(int id);
        IResult Add(T item);
        IResult Update(T item);
        IResult Delete(T item);
    }
}
