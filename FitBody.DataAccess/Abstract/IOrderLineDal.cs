using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Abstract
{
  public  interface IOrderLineDal:IRepository<OrderLine>
    {
        int GetAllSaleCount();
    }
}
