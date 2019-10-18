using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
   public class About :IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
