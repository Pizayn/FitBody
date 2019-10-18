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
   public class OrderManager:IOrderService
   {
       private IOrderDal _orderDal;

       public OrderManager(IOrderDal orderDal)
       {
           _orderDal = orderDal;
       }

       public void Add(Order order)
        {
           _orderDal.Add(order);
        }

        public void Delete(Order order)
        {
           _orderDal.Delete(order);
        }

        public void Update(Order order)
        {
           _orderDal.Update(order);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetList();
        }

        public List<Order> GetOrderById(int orderId)
        {
            return _orderDal.GetList(x => x.ID == orderId);
        }

        public List<Order> GetOrderByAccountId(string accountId)
        {
            return _orderDal.GetList(x => x.AccountId == accountId);
        }
   }
}
