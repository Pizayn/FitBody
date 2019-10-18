using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FitBody.WebUI.ViewComponents
{
    public class ExerciseVİewComponentModel:ViewComponent
    {
        private IExerciseService _exerciseService;

        public ExerciseVİewComponentModel(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public ViewViewComponentResult Invoke()
        {
            ExerciseViewModel exerciseViewModel= new ExerciseViewModel()
            {
                Exercises = _exerciseService.GetAll(),
            }; 
            return View(exerciseViewModel);
        }
    }
}
