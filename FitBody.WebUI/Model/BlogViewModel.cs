using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class BlogViewModel
    {
        public List<BlogPost> BlogPosts { get; set; }
        public BlogPost BlogPost { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
      
    }
}
