using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Concrete
{
   public class SupplementDal:Repository<Supplement,FitBodyContext>,ISupplementDal
    {
        public int GetAllUnitInStock()
        {
            FitBodyContext context=new FitBodyContext();
            var unitInStock = 0;
            foreach (var item in context.Supplements)
            {
                unitInStock += item.UnitInStock;
            }

            return unitInStock;
        }
    }
}
