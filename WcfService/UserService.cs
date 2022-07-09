using ApplicationService.DTOs;
using ApplicationService.Implementaions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {
        private UserManagementService service = new UserManagementService();

        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public UserDTO GetUserById(int id)
        {
            return this.service.GetById(id);
        }

        public List<UserDTO> GetUsers()
        {
            return this.service.Get();
        }

        public bool Login(UserLoginDTO userDto)
        {
            return this.service.Login(userDto);
        }

        public bool Save(UserDTO nationalityDTO)
        {
            return this.service.Save(nationalityDTO);
        }
    }
}
