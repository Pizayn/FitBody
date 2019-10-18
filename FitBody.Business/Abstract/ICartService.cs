using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface ICartService
   {
       void AddToCart(Cart cart, Supplement supplement);
       void RemoveToCart(Cart cart, int supplementId);
       List<CartLine> Carts(Cart cart);
   }
}
