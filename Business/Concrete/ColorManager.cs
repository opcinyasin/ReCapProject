using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorDal
    {

        IColorDal colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this.colorDal = colorDal;
        }

        public void Add(Color color)
        {
            colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return colorDal.GetAll();
        }

        public Color GetById(int Id)
        {
            return colorDal.GetById(Id);
        }

        public bool isBrandId(int Id)
        {
            return colorDal.isBrandId(Id);
        }

        public void Update(Color color)
        {
            colorDal.Update(color);
        }
    }
}
