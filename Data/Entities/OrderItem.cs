using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
        public virtual Flower Flower { get; set; }
        public virtual Order Order { get; set; }
    }
}
