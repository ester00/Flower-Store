using ApplicationService.DTOs;

namespace MVC.Models.Users
{
    public class UserIndexViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public UserIndexViewModel(UserDTO userDTO)
        {
            this.Id = userDTO.Id;
            this.UserName = userDTO.UserName;
        }
        public UserIndexViewModel()
        {

        }
    }
}
