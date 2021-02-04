using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IModelService
    {
        void Add(Model model);


        void Delete(Model model);


        List<Model> GetAll();


        void Update(Model model);
        
    }
}
