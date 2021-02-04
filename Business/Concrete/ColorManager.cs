using Business.Abstract;
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

        public bool isColorId(int Id)
        {
            return colorDal.isColorId(Id);
        }

        public void Update(Color color)
        {
            colorDal.Update(color);
        }
    }
}
