using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult("Eklendi");
        }

        public void Delete(Model model)
        {
            _modelDal.Delete(model);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }


        public void Update(Model model)
        {
            _modelDal.Update(model);
        }
    }
}
