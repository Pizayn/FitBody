using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class ExerciseAddViewModel
    {
        public Exercise Exercise { get; set; }
        public List<ExerciseType>  ExerciseTypes { get; set; }
    }
}
