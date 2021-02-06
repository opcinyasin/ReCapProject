using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarPto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public string ColorName { get; set; }
        public string ModelYear { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }
    }
}
