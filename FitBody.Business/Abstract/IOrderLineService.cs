using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface IOrderLineService
    {
        void Add(OrderLine orderLine);
        void Delete(OrderLine orderLine);
        void Update(OrderLine orderLine);
        List<OrderLine> GetAll();
        int GetAllSaleCount();
    }
}
