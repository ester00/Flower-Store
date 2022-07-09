using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class FlowerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public double Price { get; set; }

        public FlowerDTO(Flower flower)
        {
            this.Id = flower.Id;
            this.Name = flower.Name;
            this.Price = flower.Price;
            this.PictureURL = flower.PictureURL;
        }

        public FlowerDTO()
        {

        }
    }
}
