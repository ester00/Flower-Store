using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FlowerId { get; set; }
        public int Quantity { get; set; }
        public virtual FlowerDTO Flower { get; set; }
        public virtual OrderDTO Order { get; set; }

        public OrderItemDTO()
        {

        }

        public OrderItemDTO(OrderItem orderItem)
        {
            this.OrderId = orderItem.OrderId;
            this.Id = orderItem.Id;
            this.FlowerId = orderItem.FlowerId;
            this.Quantity = orderItem.Quantity;
            if (orderItem.Flower != null)
            {
                this.Flower = new FlowerDTO(orderItem.Flower);
            }
            if (orderItem.Order != null)
            {
                this.Order = new OrderDTO(orderItem.Order);
            }
        }
    }
}
