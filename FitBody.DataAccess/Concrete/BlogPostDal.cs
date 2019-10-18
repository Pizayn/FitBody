using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Concrete
{
    public class BlogPostDal:Repository<BlogPost,FitBodyContext>,IBlogPostDal
    {
        public int GetBlogPostCount()
        {
           FitBodyContext context=new FitBodyContext();
           return context.BlogPosts.Count();

        }
    }
}
