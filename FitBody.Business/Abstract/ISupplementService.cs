using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface ISupplementService
    {
        void Add(Supplement supplement);
        void Delete(Supplement supplement);
        void Update(Supplement supplement);
        List<Supplement> GetAll();
        Supplement GetSupplementById(int supplementId);
        List<Supplement> GetSupplementByCategoryAndSubCategory(int categoryId, int subCategoryId);
        int GetAllUnitInStock();
    }
}
