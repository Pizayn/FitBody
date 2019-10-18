using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Services
{
  public  interface ICartSessionService
  {
      Cart GetCart();
      void SetCart(Cart cart);
  }
}
