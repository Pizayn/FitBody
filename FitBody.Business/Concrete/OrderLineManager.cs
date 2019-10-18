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
  public class OrderLineManager:IOrderLineService
  {
      private IOrderLineDal _orderLineDal;

      public OrderLineManager(IOrderLineDal orderLineDal)
      {
          _orderLineDal = orderLineDal;
      }

      public void Add(OrderLine orderLine)
        {
           _orderLineDal.Add(orderLine);
        }

        public void Delete(OrderLine orderLine)
        {
            _orderLineDal.Delete(orderLine);
        }

        public void Update(OrderLine orderLine)
        {
            _orderLineDal.Update(orderLine);
        }

        public List<OrderLine> GetAll()
        {
           return _orderLineDal.GetList();
        }

        public int GetAllSaleCount()
        {
            return _orderLineDal.GetAllSaleCount();
        }
  }
}
