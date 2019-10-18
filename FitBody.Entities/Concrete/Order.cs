using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
   public class Order: IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string AccountId { get; set; }

        public int ShippingDetailId { get; set; }


        public virtual ICollection<OrderLine> OrderLines{ get; set; }

    }
}
