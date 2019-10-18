using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
   public class BlogPost:IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Image { get; set; }


    }
}
