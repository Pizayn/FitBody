using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    public class NewsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IBlogPostService _blogPostService;

        public NewsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IActionResult Index(int page=1)
        {
            int pageSize = 6;
            var blogPost = _blogPostService.GetAll();
           BlogViewModel model=new BlogViewModel()
           {
               BlogPosts = blogPost.Skip((page-1)*pageSize).Take(pageSize).ToList(),
               CurrentPage = page,
               PageCount = (int)Math.Ceiling(blogPost.Count/(double)pageSize),
               PageSize = pageSize

           };
            return View(model);
        }

        
        public   IActionResult Details(int id)
        {
            BlogViewModel model = new BlogViewModel()
            {
               BlogPost = _blogPostService.GetByBlogPostId(id)
            };
            return View(model);
        }
    }
}