using ApplicationService.DTOs;
using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Flowers;

namespace MVC.Controllers
{
    public class FlowersController : Controller
    {
        private FlowerManagementService flowerManagementService = new FlowerManagementService();

        public IActionResult Index()
        {
            List<FlowerIndexViewModel> flowersVM = new List<FlowerIndexViewModel>();
            foreach (var flower in flowerManagementService.Get())
            {
                flowersVM.Add(new FlowerIndexViewModel(flower));
            }

            return View(flowersVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new FlowersCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(FlowersCreateViewModel flowerCreateViewModel)
        {
            FlowerDTO flowerDTO = new FlowerDTO();
            flowerDTO.Name = flowerCreateViewModel.Name;
            flowerDTO.Price = flowerCreateViewModel.Price;
            flowerDTO.PictureURL = flowerCreateViewModel.PictureURL;
            flowerManagementService.Save(flowerDTO);

            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            var flower = flowerManagementService.GetById(id);

            return View(new FlowerDetailsViewModel(flower));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var flower = flowerManagementService.GetById(id);

            return View(new FlowerDetailsViewModel(flower));
        }

        [HttpPost]
        public IActionResult Edit(FlowerDetailsViewModel model)
        {
            FlowerDTO flowerDto = new FlowerDTO();

            flowerDto.Id = model.Id;
            flowerDto.Name = model.Name;
            flowerDto.Price = model.Price;
            flowerDto.PictureURL = model.PictureURL;

            flowerManagementService.Update(flowerDto);

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var flower = flowerManagementService.GetById(id);

            return View(new FlowerDetailsViewModel(flower));
        }

        [HttpPost]
        public IActionResult Delete(FlowerDetailsViewModel model)
        {
            var flower = flowerManagementService.Delete(model.Id);

            return RedirectToAction("index");
        }
    }
}
