using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    public class ExerciseController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public IActionResult Details(int exerciseId)
        {
            ExerciseViewModel exerciseViewModel= new ExerciseViewModel()
            {
                Exercise = _exerciseService.GetExerciseByExerciseId(exerciseId)
            };
            return View(exerciseViewModel);
        }
    }
}