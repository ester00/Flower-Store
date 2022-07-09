using ApplicationService.DTOs;

namespace MVC.Models.Users
{
    public class UserEditViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserEditViewModel(UserDTO user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
        }

        public UserEditViewModel()
        {

        }
    }
}
