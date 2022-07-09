using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual List<OrderItemDTO> Items { get; set; }

        public OrderDTO()
        {

        }

        public OrderDTO(Order order)
        {
            this.Id = order.Id;
            this.UserId = order.UserId;
        }
    }
}
