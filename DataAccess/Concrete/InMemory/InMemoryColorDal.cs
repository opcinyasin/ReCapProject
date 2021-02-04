using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colorList;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color GetById(int Id)
        {
            return _colorList.SingleOrDefault(c=>c.ColorId==Id);
        }

        public bool isColorId(int Id)
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
