using ApplicationService.DTOs;

namespace MVC.Models.Flowers
{
    public class FlowerDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PictureURL{ get; set; }

        public FlowerDetailsViewModel(FlowerDTO flowerDTO)
        {
            this.Id = flowerDTO.Id;
            this.Name = flowerDTO.Name;
            this.Price = flowerDTO.Price;
            this.PictureURL = flowerDTO.PictureURL;
        }
        public FlowerDetailsViewModel()
        {

        }
    }
}
