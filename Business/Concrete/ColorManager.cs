using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            colorDal.Add(color);
            return new SuccessResult("Eklendi");
        }

        public void Delete(Color color)
        {
            colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return colorDal.GetAll();
        }


        public void Update(Color color)
        {
            colorDal.Update(color);
        }
    }
}
