using ApplicationService.DTOs;
using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Users;
using System.Net;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private UserManagementService userManagementService = new UserManagementService();

        public IActionResult Index()
        {
            List<UserIndexViewModel> usersVM = new List<UserIndexViewModel>();
            foreach (var user in userManagementService.Get())
            {
                usersVM.Add(new UserIndexViewModel(user));
            }


            return View(usersVM);
        }

        public ActionResult Details(int id)
        {
            var user = userManagementService.GetById(id);

            return View(new UserIndexViewModel(user));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = userManagementService.GetById(id);

            return View(new UserIndexViewModel(user));
        }

        [HttpPost]
        public IActionResult Delete(UserIndexViewModel model)
        {
            var user = userManagementService.Delete(model.Id);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel userCreateViewModel)
        {
            UserDTO userDto = new UserDTO();

            userDto.UserName = userCreateViewModel.UserName;
            userDto.Password = userCreateViewModel.Password;

            userManagementService.Save(userDto);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userManagementService.GetById(id);

            return View(new UserEditViewModel(user));
        }

        [HttpPost]
        public IActionResult Edit(UserEditViewModel model)
        {
            UserDTO userDto = new UserDTO();

            userDto.Id = model.Id;
            userDto.UserName = model.UserName;
            userDto.Password = model.Password;

            userManagementService.Update(userDto);

            return RedirectToAction("index");
        }
    }
}
