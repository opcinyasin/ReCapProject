using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {

        List<Color> _colorList;

        public InMemoryColorDal()
        {
            _colorList = new List<Color> {  new Color { ColorId=1, ColorName="Beyaz"},
                                            new Color { ColorId=2, ColorName="Siyah"},
                                            new Color { ColorId=3, ColorName="Kırmızı"},
                                            new Color { ColorId=4, ColorName="Mavi"},
                                            new Color { ColorId=5, ColorName="Gri"}
            };
        }

        public void Add(Color color)
        {
            _colorList.Add(color);
        }

        public void Delete(Color color)
        {
            Color _color = _colorList.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colorList.Remove(_color);
        }

        public List<Color> GetAll()
        {
            return _colorList;
        }

        public Color GetById(int Id)
        {
            return _colorList.SingleOrDefault(c=>c.ColorId==Id);
        }

        public bool isBrandId(int Id)
        {
            return _colorList.Where(c => c.ColorId == Id).Any();
        }

        public void Update(Color color)
        {
            Color _color = _colorList.SingleOrDefault(c => c.ColorId == color.ColorId);
            _color.ColorName = color.ColorName;
        }
    }
}
