using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Abstract;

namespace FitBody.Entities.Concrete
{
  public  class ShippingDetail:IEntity
    {

        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string AccountId { get; set; }
      
     
        
    }
}
