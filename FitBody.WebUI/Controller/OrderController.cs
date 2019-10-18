using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using FitBody.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    [Authorize]
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ISupplementService _supplementService;
        private ICartSessionService _cartSessionService;
        private IOrderLineService _orderLineService;
        private IOrderService _orderService;
        private IShippingDetailService _shippingDetailService;
        private IHttpContextAccessor _httpContextAccessor;
        
        private UserManager<CustomIdentityUser> _userManager;

        public OrderController(IOrderService orderService, IOrderLineService orderLineService, ICartSessionService cartSessionService, ISupplementService supplementService, IHttpContextAccessor httpContextAccessor, UserManager<CustomIdentityUser> userManager, IShippingDetailService shippingDetailService)
        {
            _orderService = orderService;
            _orderLineService = orderLineService;
            _cartSessionService = cartSessionService;
            _supplementService = supplementService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _shippingDetailService = shippingDetailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Complete()
        {
            ShippingDetailViewModel shippingDetailViewModel=new ShippingDetailViewModel()
            {
                ShippingDetail = new ShippingDetail(),
            };
            return View(shippingDetailViewModel);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            

        
            
                var cart = _cartSessionService.GetCart();
                shippingDetail.AccountId = _userManager.GetUserId(HttpContext.User);
                shippingDetail.Time = DateTime.Today;
                _shippingDetailService.Add(shippingDetail);
                
                Order order = new Order()
                {
                    AccountId = _userManager.GetUserId(HttpContext.User),
                    ShippingDetailId = shippingDetail.ID,
                    Total = cart.Total,
                   
                    

                    
                    
                    
            };
               _orderService.Add(order);
                foreach (var item in cart.CartLines)
                {
                    if (item.Supplement.UnitInStock>item.Quantity)
                    {
                        item.Supplement.UnitInStock = (item.Supplement.UnitInStock - item.Quantity);
                        _supplementService.Update(item.Supplement);


                       

                        OrderLine orderLine=new OrderLine();
                        orderLine.OrderID = order.ID;
                        orderLine.Price = item.Supplement.Price;
                        orderLine.SupplementID = item.Supplement.ID;
                        orderLine.Quantity = item.Quantity;
                        orderLine.AccountId = _userManager.GetUserId(HttpContext.User);
                        orderLine.Time=DateTime.Today;
                        _orderLineService.Add(orderLine);
                        


                    }
                }
                cart.CartLines.Clear();
                TempData.Add("message","Your products successfully completed");
               


                return RedirectToAction("Details");


        }

        public IActionResult Details(int orderId=0)
        {
            FitBodyContext context=new FitBodyContext();
            var details = from o in context.Orders
                join ol in context.OrderLines on o.ID equals ol.OrderID
                join s in context.Supplements on ol.SupplementID equals s.ID
                join sd in context.ShippingDetails on o.ShippingDetailId equals sd.ID 
               
                where o.ID == orderId
                select new OrderDetailsModel()
                {
                    Image = s.Image,
                    Quantity = ol.Quantity,
                    SupplementName = s.SupplementName,
                    Price = ol.Price,
                    Total = o.Total,
                    AccountId = o.AccountId,
                    City =sd.City,
                    District = sd.District,
                    Neighborhood = sd.Neighborhood,
                    SupplementId = s.ID,
                    Name = sd.Name,
                    Surname = sd.Surname,
                    Time = sd.Time,
                    
                };
            OrderDetailsListModel orderDetailsListModel=new OrderDetailsListModel
            {
                 OrderDetailsModels = details.ToList(),
                 Orders = _orderService.GetOrderById(orderId),
            };
            if (orderId==0)
            {
                orderDetailsListModel.Orders =
                    _orderService.GetOrderByAccountId(_userManager.GetUserId(HttpContext.User));
            }
            return View(orderDetailsListModel);
        }
    }
}