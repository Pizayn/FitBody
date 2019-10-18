using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface ISupplementSubCategoryService
    {
        void Add(SupplementSubCategory supplementSubCategory);
        void Delete(SupplementSubCategory supplementSubCategory);
        void Update(SupplementSubCategory supplementSubCategory);
        List<SupplementSubCategory> GetAll();
    }
}
