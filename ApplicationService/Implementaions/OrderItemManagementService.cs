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
    public class OrderItemManagementService
    {
        public List<OrderItemDTO> Get()
        {
            List<OrderItemDTO> orderItemsDto = new List<OrderItemDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.OrderItemRepository.Get())
                {

                    OrderItemDTO dto = new OrderItemDTO();
                    dto.Id = item.Id;
                    dto.OrderId = item.OrderId;
                    dto.FlowerId = item.FlowerId;
                    dto.Quantity = item.Quantity;
                    AddMissing(dto, item);
                    orderItemsDto.Add(dto);
                }
            }
            return orderItemsDto;
        }
        public OrderItemDTO GetById(int id)
        {
            OrderItemDTO orderItemsDTO = new OrderItemDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                OrderItem orderItem = unitOfWork.OrderItemRepository.GetByID(id);
                if (orderItem != null)
                {
                    orderItemsDTO = new OrderItemDTO
                    {
                        Id = orderItem.Id,
                        OrderId = orderItem.OrderId,
                        FlowerId = orderItem.FlowerId,
                        Quantity = orderItem.Quantity,
                    };
                    AddMissing(orderItemsDTO, orderItem);
                }
            }

            return orderItemsDTO;
        }
        private static void AddMissing(OrderItemDTO orderItemDTO, OrderItem orderItem)
        {
            if (orderItem.Order != null)
            {
                OrderDTO orderDTO = new OrderDTO();
                orderDTO.Id = orderItem.Id;
                orderDTO.UserId = orderItem.Order.UserId;
                orderItemDTO.Order = orderDTO;
            }
             if(orderItem.Order.User != null)
             {
                User user = orderItem.Order.User;
                UserDTO userDTO = new UserDTO();
                userDTO.Id = user.Id;
                userDTO.UserName = user.UserName;
                orderItemDTO.Order.User = userDTO;
             }
            if (orderItem.Flower != null)
            {
                FlowerDTO flowerDTO = new FlowerDTO();
                flowerDTO.Id = orderItem.Order.Id;
                flowerDTO.Name = orderItem.Flower.Name;
                flowerDTO.Price = orderItem.Flower.Price;
                flowerDTO.PictureURL = orderItem.Flower.PictureURL;
                orderItemDTO.Flower = flowerDTO;
            }
        }
        public bool Save(OrderItemDTO orderItemsDTO)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderId = orderItemsDTO.OrderId,
                FlowerId = orderItemsDTO.FlowerId,
                Quantity = orderItemsDTO.Quantity,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderItemRepository.Insert(orderItem);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    OrderItem orderItem = unitOfWork.OrderItemRepository.GetByID(id);
                    unitOfWork.OrderItemRepository.Delete(orderItem);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(OrderItemDTO orderItemDto)
        {
            OrderItem orderItem = new OrderItem()
            {
                Id = orderItemDto.Id,
                OrderId = orderItemDto.OrderId,
                FlowerId = orderItemDto.FlowerId,
                Quantity = orderItemDto.Quantity,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderItemRepository.Update(orderItem);
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
