using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IModelDal
    {
        List<Model> GetAll();
        void Add(Model model);
        void Update(Model model);
        void Delete(Model model);
    }
}
