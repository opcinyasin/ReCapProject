using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelManager : IModelDal
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void Add(Model model)
        {
            _modelDal.Add(model);
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public Model GetById(int Id)
        {
            return _modelDal.GetById(Id);
        }

        public bool isModelId(int Id)
        {
            return _modelDal.isModelId(Id);
        }

        public void Update(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
