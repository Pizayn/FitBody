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
   public class ShippingDetailManager:IShippingDetailService
   {
       private IShippingDetailDal _shippingDetailDal;

       public ShippingDetailManager(IShippingDetailDal shippingDetailDal)
       {
           _shippingDetailDal = shippingDetailDal;
       }

       public void Add(ShippingDetail shippingDetail)
        {
            _shippingDetailDal.Add(shippingDetail);
        }

        public void Delete(ShippingDetail shippingDetail)
        {
           _shippingDetailDal.Delete(shippingDetail);
        }

        public void Update(ShippingDetail shippingDetail)
        {
           _shippingDetailDal.Update(shippingDetail);
        }

        public List<ShippingDetail> GetAll()
        {
            return _shippingDetailDal.GetList();
        }

        public ShippingDetail GetShippingDetailById(int shippingDetailId)
        {

            return _shippingDetailDal.Get(x => x.ID == shippingDetailId);
        }
    }
}
