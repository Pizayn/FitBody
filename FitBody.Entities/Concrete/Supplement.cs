using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace FitBody.Entities.Concrete
{
   public class Supplement: IEntity
    {
      
        public int ID { get; set; }
        [Required]
        public string SupplementName { get; set; }
        [Required]
        public string Description { get; set; }
       
        public byte[] Image { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int UnitInStock { get; set; }
        [Required]
        public int SupplementCategoryID { get; set; }
        [Required]
        public int SupplementSubCategoryID { get; set; }
       
        public DateTime Time { get; set; }
       

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual SupplementCategory SupplementCategory { get; set; }
        public virtual SupplementSubCategory SupplementSubCategory { get; set; }


    }
}
