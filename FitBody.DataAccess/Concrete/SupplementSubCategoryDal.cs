using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Concrete
{
   public class SupplementSubCategoryDal:Repository<SupplementSubCategory,FitBodyContext>,ISupplementSubCategoryDal
    {
    }
}
