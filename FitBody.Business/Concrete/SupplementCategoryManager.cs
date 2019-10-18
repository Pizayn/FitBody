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
   public class SupplementCategoryManager:ISupplementCategoryService
   {
       private ISupplementCategoryDal _supplementCategoryDal;

       public SupplementCategoryManager(ISupplementCategoryDal supplementCategoryDal)
       {
           _supplementCategoryDal = supplementCategoryDal;
       }

       public void Add(SupplementCategory supplementCategory)
        {
           _supplementCategoryDal.Add(supplementCategory);
        }

        public void Delete(SupplementCategory supplementCategory)
        {
            _supplementCategoryDal.Delete(supplementCategory);
        }

        public void Update(SupplementCategory supplementCategory)
        {
            _supplementCategoryDal.Update(supplementCategory);
        }

        public List<SupplementCategory> GetAll()
        {
           return _supplementCategoryDal.GetList();
        }
    }
}
