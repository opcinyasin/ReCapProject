using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        public IDataResult<List<Model>> getById(int id)
        {

            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.ModelId == id));

        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}
