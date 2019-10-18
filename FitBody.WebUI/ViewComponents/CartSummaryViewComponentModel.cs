using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.WebUI.Model;
using FitBody.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FitBody.WebUI.ViewComponents
{
    public class CartSummaryViewComponentModel:ViewComponent
    {
        private ICartSessionService _cartService;

        public CartSummaryViewComponentModel(ICartSessionService cartService)
        {
            _cartService = cartService;
        }

        public  ViewViewComponentResult Invoke()
      {
            CartSummaryModel cartSummaryModel=new CartSummaryModel()
            {
                Cart = _cartService.GetCart()
            };
          return View(cartSummaryModel);
      }
    }
}
