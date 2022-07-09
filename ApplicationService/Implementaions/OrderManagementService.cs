using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementaions
{
    public class OrderManagementService
    {
        public List<OrderDTO> Get()
        {
            List<OrderDTO> ordersDto = new List<OrderDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.OrderRepository.Get())
                {

                    OrderDTO dto = new OrderDTO();
                    dto.UserId = item.UserId;
                    dto.Id = item.Id;
                    AddMissing(dto, item);
                    ordersDto.Add(dto);
                }
            }
            return ordersDto;
        }
        public OrderDTO GetById(int id)
        {
            OrderDTO ordersDTO = new OrderDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Order order = unitOfWork.OrderRepository.GetByID(id);
                if (order != null)
                {
                    ordersDTO = new OrderDTO
                    {
                        Id = order.Id,
                        UserId = order.UserId,
                    };
                    AddMissing(ordersDTO, order);
                }
            }

            return ordersDTO;
        }

        private static void AddMissing(OrderDTO ordersDTO, Order order)
        {
            if (order.User != null)
            {
                UserDTO usersDTO = new UserDTO();
                usersDTO.Id = order.User.Id;
                usersDTO.UserName = order.User.UserName;
                ordersDTO.User = usersDTO;
            }

            if (order.OrderItems != null)
            {
                List<OrderItemDTO> ordeItems = new List<OrderItemDTO>();
                foreach (var item in order.OrderItems)
                {
                    ordeItems.Add(new OrderItemDTO(item));
                }
                ordersDTO.Items = ordeItems;
            }
        }

        public int Save(OrderDTO ordersDTO)
        {
            Order order = new Order()
            {
                UserId = ordersDTO.UserId,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var createdOrder = unitOfWork.OrderRepository.Insert(order);
                    unitOfWork.Save();
                    return createdOrder.Id;
                }

            }
            catch
            {
                return 0;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Order orders = unitOfWork.OrderRepository.GetByID(id);
                    unitOfWork.OrderRepository.Delete(orders);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(OrderDTO orderDto)
        {
            Order order = new Order()
            {
                Id = orderDto.Id,
                UserId = orderDto.UserId,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderRepository.Update(order);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
