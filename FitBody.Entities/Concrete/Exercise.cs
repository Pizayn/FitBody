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
   public class Exercise: IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public string  Image { get; set; }
        [Required]
        public int ExerciseTypeID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Summary { get; set; }
   


        public virtual ExerciseType ExerciseType { get; set; }
        
    }
}
