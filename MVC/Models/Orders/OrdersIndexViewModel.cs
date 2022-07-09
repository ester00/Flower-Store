using ApplicationService.DTOs;

namespace MVC.Models.Orders
{
    public class OrdersIndexViewModel
    {
        public int Id { get; set; }
        public string UserUserName { get; set; }

        public OrdersIndexViewModel(OrderDTO orderDTO)
        {
            this.Id = orderDTO.Id;
            this.UserUserName = orderDTO.User.UserName;
        }
        public OrdersIndexViewModel()
        {

        }
    }
}
