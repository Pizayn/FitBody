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
    public class CategoryViewComponent:ViewComponent
    {
        private ISupplementCategoryService _supplementCategoryService;
        private ISupplementSubCategoryService _supplementSubCategoryService;

        public CategoryViewComponent(ISupplementCategoryService supplementCategoryService, ISupplementSubCategoryService supplementSubCategoryService)
        {
            _supplementCategoryService = supplementCategoryService;
            _supplementSubCategoryService = supplementSubCategoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            CategoryViewComponentModel categoryViewComponentModel=new CategoryViewComponentModel()
            {
                SupplementCategories = _supplementCategoryService.GetAll(),
                SupplementSubCategories = _supplementSubCategoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"]),
                CurrentSubCategory = Convert.ToInt32 (HttpContext.Request.Query["subCategory"]),
                CurrentAction = HttpContext.Request.Path,
                

            };
            return View(categoryViewComponentModel);
        }
    }
}
