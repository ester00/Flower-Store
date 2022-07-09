using ApplicationService.DTOs;

namespace MVC.Models.Flowers
{
    public class FlowerIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public FlowerIndexViewModel(FlowerDTO flowerDTO)
        {
            this.Id = flowerDTO.Id;
            this.Name = flowerDTO.Name;
            this.Price = flowerDTO.Price;
        }
        //comment
        public FlowerIndexViewModel()
        {

        }
    }
}
