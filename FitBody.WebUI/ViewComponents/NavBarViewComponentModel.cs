using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FitBody.WebUI.ViewComponents
{
    public class NavBarViewComponentModel:ViewComponent
    {
        private ISupplementSubCategoryService _supplementSubCategoryService;
        private ISupplementCategoryService _supplementCategoryService;

        public NavBarViewComponentModel(ISupplementSubCategoryService supplementSubCategoryService, ISupplementCategoryService supplementCategoryService)
        {
            _supplementSubCategoryService = supplementSubCategoryService;
            _supplementCategoryService = supplementCategoryService;
        }

        public ViewViewComponentResult Invoke()
        {
           SupplementNavbarViewModel navbarViewModel=new SupplementNavbarViewModel()
           {
               SupplementSubCategories = _supplementSubCategoryService.GetAll(),
               SupplementCategories = _supplementCategoryService.GetAll(),

           };
            return View(navbarViewModel);
        }
    }
}
