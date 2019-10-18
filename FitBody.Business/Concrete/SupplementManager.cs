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
   public class SupplementManager:ISupplementService
   {
       private ISupplementDal _supplementDal;

       public SupplementManager(ISupplementDal supplementDal)
       {
           _supplementDal = supplementDal;
       }

       public void Add(Supplement supplement)
        {
           _supplementDal.Add(supplement);
        }

        public void Delete(Supplement supplement)
        {
            _supplementDal.Delete(supplement);
        }

        public void Update(Supplement supplement)
        {
            _supplementDal.Update(supplement);
        }

        public List<Supplement> GetAll()
        {
          return  _supplementDal.GetList();
        }

        public Supplement GetSupplementById(int supplementId)
        {
            return _supplementDal.Get(x => x.ID == supplementId);
        }

        public List<Supplement> GetSupplementByCategoryAndSubCategory(int categoryId, int subCategoryId)
        {
            return _supplementDal.GetList(x =>
                (x.SupplementCategoryID == categoryId || categoryId == 0) &&
                (x.SupplementSubCategoryID == subCategoryId || subCategoryId == 0));
        }

        public int GetAllUnitInStock()
        {
            return _supplementDal.GetAllUnitInStock();
        }
   }
}
