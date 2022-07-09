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
    public class UserManagementService
    {
        public List<UserDTO> Get()
        {
            List<UserDTO> nationalitiesDto = new List<UserDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.UserRepository.Get())
                {

                    nationalitiesDto.Add(new UserDTO
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Password = item.Password
                    });

                }
            }

            return nationalitiesDto;
        }

        public UserDTO GetById(int id)
        {
            UserDTO nationalityDTO = new UserDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByID(id);
                if (user != null)
                {
                    nationalityDTO = new UserDTO
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Password = user.Password
                    };
                }
            }

            return nationalityDTO;
        }

        public bool Login(UserLoginDTO userDto)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetByUserName(userDto.UserName);
                if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
                {
                    return false;
                }

                return true;
            }

        }

        public bool Save(UserDTO nationalityDTO)
        {
            User user = new User()
            {
                UserName = nationalityDTO.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(nationalityDTO.Password)
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Insert(user);
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
                    User nationality = unitOfWork.UserRepository.GetByID(id);
                    unitOfWork.UserRepository.Delete(nationality);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(UserDTO userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.UserRepository.Update(user);
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
