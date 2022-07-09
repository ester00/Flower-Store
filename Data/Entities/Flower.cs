using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Flower : BaseEntity
    {
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public double Price { get; set; }
    }
}
