using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Concrete
{
   public class CartManager:ICartService
    {
        public void AddToCart(Cart cart, Supplement supplement)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Supplement.ID == supplement.ID);
            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine {Supplement = supplement,Quantity = 1});
        }

        public void RemoveToCart(Cart cart, int supplementId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(p => p.Supplement.ID == supplementId));
        }

        public List<CartLine> Carts(Cart cart)
        {
            return cart.CartLines;
        }   
    }
}
