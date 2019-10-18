using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
  public  class Trainer:IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string TrainerName { get; set; }
        [Required]
        public string TrainerSurname { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public byte[] Image { get; set; }

    }
}
