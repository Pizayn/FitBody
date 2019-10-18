using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
  public  interface IOrderService
    {
        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
        List<Order> GetAll();
        List<Order> GetOrderById(int orderId);
        List<Order> GetOrderByAccountId(string accountId);
    }
}
