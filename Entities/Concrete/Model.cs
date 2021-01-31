using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}
