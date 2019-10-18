using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
    public interface IShippingDetailService
    {
        void Add(ShippingDetail shippingDetail);
        void Delete(ShippingDetail shippingDetail);
        void Update(ShippingDetail shippingDetail);
        List<ShippingDetail> GetAll();
        ShippingDetail GetShippingDetailById(int shippingDetailId);
    }
}
