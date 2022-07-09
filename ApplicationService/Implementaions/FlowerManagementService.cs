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
    public class FlowerManagementService
    {
        public List<FlowerDTO> Get()
        {
            List<FlowerDTO> flowersDto = new List<FlowerDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.FlowerRepository.Get())
                {

                    flowersDto.Add(new FlowerDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        PictureURL = item.PictureURL,
                        Price = item.Price,
                    });

                }
            }

            return flowersDto;
        }

        public FlowerDTO GetById(int id)
        {
            FlowerDTO flowersDTO = new FlowerDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Flower flower = unitOfWork.FlowerRepository.GetByID(id);
                if (flower != null)
                {
                    flowersDTO = new FlowerDTO
                    {
                        Id = flower.Id,
                        Name=flower.Name,
                        PictureURL=flower.PictureURL,
                        Price=flower.Price,
                    };
                }
            }

            return flowersDTO;
        }

        public bool Save(FlowerDTO flowersDTO)
        {
            Flower flower = new Flower()
            {
                Name = flowersDTO.Name,
                PictureURL = flowersDTO.PictureURL,
                Price = flowersDTO.Price,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.FlowerRepository.Insert(flower);
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
                    Flower flowers = unitOfWork.FlowerRepository.GetByID(id);
                    unitOfWork.FlowerRepository.Delete(flowers);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(FlowerDTO flowerDto)
        {
            Flower flower = new Flower()
            {
                Id = flowerDto.Id,
                Name = flowerDto.Name,
                PictureURL= flowerDto.PictureURL,
                Price= flowerDto.Price,
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.FlowerRepository.Update(flower);
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
