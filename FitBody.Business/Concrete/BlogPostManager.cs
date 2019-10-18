using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Concrete
{
  public  class BlogPostManager:IBlogPostService
  {
      private IBlogPostDal _blogPostDal;

      public BlogPostManager(IBlogPostDal blogPostDal)
      {
          _blogPostDal = blogPostDal;
      }

      public void Add(BlogPost blogPost)
        {
           _blogPostDal.Add(blogPost);
        }

        public void Delete(BlogPost blogPost)
        {
            _blogPostDal.Delete(blogPost);
        }

        public void Update(BlogPost blogPost)
        {
          _blogPostDal.Update(blogPost);
        }

        public List<BlogPost> GetAll()
        {
            return _blogPostDal.GetList();
        }

        public BlogPost GetByBlogPostId(int blogPostId)
        {

            return _blogPostDal.Get(x => x.ID == blogPostId);
        }

        public int GetBlogPostCount()
        {
            return _blogPostDal.GetBlogPostCount();
        }
  }
}
