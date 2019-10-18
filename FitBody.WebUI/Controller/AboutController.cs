using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    public class AboutController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            FitBodyContext fitBodyContext=new FitBodyContext();
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                About = fitBodyContext.Abouts.SingleOrDefault(),
            };
         
        

                return View(aboutViewModel);
        }

        public IActionResult AboutUpdate(int aboutId)
        {
            FitBodyContext fitBodyContext = new FitBodyContext();
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                About = fitBodyContext.Abouts.Where(x=>x.ID==aboutId).FirstOrDefault(),
            };
            return View(aboutViewModel);
        }
        [HttpPost]
        public IActionResult AboutUpdate(About about)
        {
            if (ModelState.IsValid)
            {
                using (FitBodyContext context = new FitBodyContext())
                {
                    context.Abouts.Update(about);
                    context.SaveChanges();
                }
                TempData.Add("message","About successfully updated");
            }
           
           return View();
        }

    }
}