using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface ISupplementCategoryService
    {
        void Add(SupplementCategory  supplementCategory);
        void Delete(SupplementCategory supplementCategory);
        void Update(SupplementCategory supplementCategory);
        List<SupplementCategory> GetAll();
    }
}
