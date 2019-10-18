using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
  public  interface IBlogPostService
  {
      void Add(BlogPost blogPost);
      void Delete(BlogPost blogPost);
      void Update(BlogPost blogPost);
      List<BlogPost> GetAll();
      BlogPost GetByBlogPostId(int blogPostId);
      int GetBlogPostCount();
  }
}
