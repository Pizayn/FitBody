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
   public class SupplementSubCategoryManager:ISupplementSubCategoryService
   {
       private ISupplementSubCategoryDal _supplementSubCategoryDal;

       public SupplementSubCategoryManager(ISupplementSubCategoryDal supplementSubCategoryDal)
       {
           _supplementSubCategoryDal = supplementSubCategoryDal;
       }

       public void Add(SupplementSubCategory supplementSubCategory)
        {
           _supplementSubCategoryDal.Add(supplementSubCategory);
        }

        public void Delete(SupplementSubCategory supplementSubCategory)
        {
            _supplementSubCategoryDal.Delete(supplementSubCategory);
        }

        public void Update(SupplementSubCategory supplementSubCategory)
        {
            _supplementSubCategoryDal.Update(supplementSubCategory);
        }

        public List<SupplementSubCategory> GetAll()
        {
         return   _supplementSubCategoryDal.GetList();
        }
    }
}
