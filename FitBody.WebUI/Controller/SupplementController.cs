using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitBody.WebUI.Controller
{
    public class SupplementController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ISupplementService _supplementService;
        private ISupplementCategoryService _supplementCategoryService;

        public SupplementController(ISupplementService supplementService, ISupplementCategoryService supplementCategoryService)
        {
            _supplementService = supplementService;
            _supplementCategoryService = supplementCategoryService;
        }

        public IActionResult Index(int category=0,int subCategory=0,int page=1,string searchProduct="")
        {
            int pageSize = 10;
            var supplements = _supplementService.GetSupplementByCategoryAndSubCategory(category, subCategory);

            SupplementListViewModel supplementViewModel =new SupplementListViewModel
            {
                Supplements = supplements.Skip(pageSize*(page-1)).Take(pageSize).ToList(),
                CurrentAction = HttpContext.Request.Path,
                CurrentCategory = category,
                CurrentSubCategory = subCategory,
                CurrentPage = page,
                PageSize = pageSize,
                PageCount =(int)Math.Ceiling(supplements.Count/(double)pageSize),

            };
           

          
            return View(supplementViewModel);
        }

        public IActionResult Details(int supplementId)
        {
           FitBodyContext context=new FitBodyContext();
           var details = from supplement in context.Supplements
               join category in context.SupplementCategories on supplement.SupplementCategoryID equals category.ID
               join subCategory in context.SupplementSubCategories on category.ID equals subCategory
                   .SupplementCategoryID
               where supplement.ID==supplementId
               select new SupplementDetailsViewModel()
               {
                   Image = supplement.Image,
                   SupplementName = supplement.SupplementName,
                   Id = supplement.ID,
                   CategoryId = category.ID,
                   SubCategoryId = subCategory.ID,
                   SupplementCategoryName = category.CategoryName,
                   SupplementSubCategoryName = subCategory.SuplementSubCategoryName,
                   UnitPrice = supplement.Price,
                   Description = supplement.Description

                   
               };
           SupplementDetailsListViewModel supplementDetailsListViewModel=new SupplementDetailsListViewModel()
           {
               SupplementDetailsViewModel = details.FirstOrDefault()
           };
           return View(supplementDetailsListViewModel);

        }

       
    }
}