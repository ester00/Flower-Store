using ApplicationService.DTOs;
using ApplicationService.Implementaions;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Orders;
using MVC.Models.Users;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private OrderManagementService orderManagementService = new OrderManagementService();
        private UserManagementService userManagementService = new UserManagementService();
        private OrderItemManagementService orderItemManagementService = new OrderItemManagementService();
        private FlowerManagementService flowerManagementService = new FlowerManagementService();
        private static List<OrderItemViewModel> orderLineItems = new List<OrderItemViewModel>();


        public IActionResult Index()
        {
            List<OrdersIndexViewModel> ordersVM = new List<OrdersIndexViewModel>();
            foreach (var order in orderManagementService.Get())
            {
                ordersVM.Add(new OrdersIndexViewModel(order));
            }

            return View(ordersVM);
        }

        [HttpGet]
        public IActionResult Create(OrderCreateViewModel orderCreateView)
        {
            List<UserIndexViewModel> usersVM = new List<UserIndexViewModel>();
            foreach (var user in userManagementService.Get())
            {
                usersVM.Add(new UserIndexViewModel(user));
            }

            List<FlowerCreateViewModel> flowers = new List<FlowerCreateViewModel>();
            foreach (var flower in flowerManagementService.Get())
            {
                flowers.Add(new FlowerCreateViewModel(flower));
            }

            ViewBag.users = usersVM;
            ViewBag.flowers = flowers;
            var model = new OrderCreateViewModel();
            if (orderCreateView != null)
            {
                model.items = orderLineItems;
                model.UserId = orderCreateView.UserId;
                model.Quantity = 0;
            }
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderCreateViewModel orderCreateView)
        {
            if (orderCreateView.Quantity != 0)
            {
                FlowerDTO flowerDTO = flowerManagementService.GetById(orderCreateView.ItemId);
                orderLineItems.Add(new OrderItemViewModel() { Quantity = orderCreateView.Quantity, FlowerName = flowerDTO.Name, FlowerId = orderCreateView.ItemId });
                return this.Create(orderCreateView);
            }

            OrderDTO orderDTO = new OrderDTO();
            orderDTO.UserId = orderCreateView.UserId;
            var orderId = orderManagementService.Save(orderDTO);
            foreach (var orderItem in orderLineItems)
            {
                orderItemManagementService.Save(new OrderItemDTO()
                {
                    OrderId = orderId,
                    Quantity = orderItem.Quantity,
                    FlowerId = orderItem.FlowerId
                });
            }
            orderLineItems.Clear();

            var a = this.orderManagementService.GetById(orderId);

            return RedirectToAction("index");
        }

        public ActionResult Details(int id)
        {
            var order = orderManagementService.GetById(id);

            return View(order);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order = orderManagementService.GetById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(UserIndexViewModel model)
        {
            orderManagementService.Delete(model.Id);

            return RedirectToAction("index");
        }
    }
}
