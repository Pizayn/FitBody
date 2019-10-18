using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using FitBody.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    public class CartController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private UserManager<CustomIdentityUser> _userManager;
        private ISupplementService _supplementService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, UserManager<CustomIdentityUser> userManager, ISupplementService supplementService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _userManager = userManager;
            _supplementService = supplementService;
        }

        public IActionResult AddToCart(int supplementId)
        {
            var cart = _cartSessionService.GetCart();
            var addedSupplement = _supplementService.GetSupplementById(supplementId);
            _cartService.AddToCart(cart,addedSupplement);
            _cartSessionService.SetCart(cart);

            return RedirectToAction("Index","Home");
        }

        public IActionResult RemoveToCart(int supplementId)
        {
            var cart = _cartSessionService.GetCart();
             _cartService.RemoveToCart(cart, supplementId);
             _cartSessionService.SetCart(cart);
             return RedirectToAction("Index", "Home");
        }

        public IActionResult ListCart()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel=new CartListViewModel()
            {
                Cart = cart
            };
            return View(cartListViewModel);

        }

      
    }
}