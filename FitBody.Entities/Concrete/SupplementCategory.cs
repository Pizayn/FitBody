using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
   public class SupplementCategory: IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
        public virtual ICollection<Supplement> Supplements{ get; set; }
        public virtual ICollection<SupplementSubCategory> SupplementSubCategories { get; set; }
    }
}
