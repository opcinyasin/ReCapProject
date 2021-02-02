using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryModelDal : IModelDal
    {


        List<Model> _modelList;

        public InMemoryModelDal()
        {
            _modelList = new List<Model>
            {
                new Model{ModelId=1, ModelName="i3"},
                new Model{ModelId=2, ModelName="a5"},
                new Model{ModelId=3,ModelName="Focus"},
                new Model{ModelId=4,ModelName="Astra"},
                new Model{ModelId=5,ModelName="Egea"}
            };
        }

        public void Add(Model model)
        {
            _modelList.Add(model);
        }

        public void Delete(Model model)
        {
            Model _model = _modelList.SingleOrDefault(m => m.ModelId == model.ModelId);
            _modelList.Remove(_model);
        }

        public List<Model> GetAll()
        {
            return _modelList;
        }

        public Model GetById(int Id)
        {
            return _modelList.SingleOrDefault(m => m.ModelId == Id);
        }

        public bool isModelId(int Id)
        {
            return _modelList.Where(m => m.ModelId == Id).Any();
        }

        public void Update(Model model)
        {
            Model _model= _modelList.SingleOrDefault(m => m.ModelId == model.ModelId);
            _model.ModelName = model.ModelName;
            
        }
    }
}
