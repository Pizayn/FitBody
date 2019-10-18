﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class FooterViewComponentModel
    {
        public List<ExerciseType> ExerciseTypes { get; set; }
        public List<Exercise>  Exercises{ get; set; }
    }
}
