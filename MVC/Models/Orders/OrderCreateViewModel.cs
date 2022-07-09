namespace MVC.Models.Orders
{
    public class OrderCreateViewModel
    {
        public OrderCreateViewModel()
        {
            this.items = new List<OrderItemViewModel>();
        }

        public int UserId { get; set; }

        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public List<OrderItemViewModel> items { get; set; }
    }
}
