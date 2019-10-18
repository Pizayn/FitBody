using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FitBody.WebUI.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {
       public ViewViewComponentResult Invoke()
       {
           return View();
       }
    }
}
