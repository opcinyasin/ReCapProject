using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IService<T> where T:class,IEntity,new()
    {
        List<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
