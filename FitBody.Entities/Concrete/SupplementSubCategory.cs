using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
    public class SupplementSubCategory: IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string SuplementSubCategoryName { get; set; }
        [Required]
        public int SupplementCategoryID { get; set; }

        public virtual ICollection<Supplement> Supplements { get; set; }
        public virtual  SupplementCategory SupplementCategory { get; set; }
    }
}
