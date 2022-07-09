using ApplicationService.DTOs;

namespace MVC.Models.Orders
{
    public class FlowerCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public FlowerCreateViewModel(FlowerDTO flower)
        {
            this.Id = flower.Id;
            this.Name = flower.Name;
        }
    }
}
