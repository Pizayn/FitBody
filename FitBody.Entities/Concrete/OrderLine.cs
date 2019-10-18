using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
  public  class OrderLine: IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int SupplementID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public string AccountId { get; set; }

        public DateTime Time { get; set; }

        public virtual Supplement  Supplement { get; set; }
        public  virtual Order Order { get; set; }

    }
}
