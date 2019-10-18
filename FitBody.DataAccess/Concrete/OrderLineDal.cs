using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Concrete
{
  public  class OrderLineDal:Repository<OrderLine,FitBodyContext>,IOrderLineDal
    {
        public int GetAllSaleCount()
        {
           FitBodyContext context=new FitBodyContext();
           var sales = 0;
           foreach (var item in context.OrderLines)
           {
               sales += item.Quantity;
           }

           return sales;
        }
    }
}
