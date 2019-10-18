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
    public class FooterViewComponent:ViewComponent
    {
        private IExerciseTypeService _exerciseTypeService;
        private IExerciseService _exerciseService;

        public FooterViewComponent(IExerciseTypeService exerciseTypeService, IExerciseService exerciseService)
        {
            _exerciseTypeService = exerciseTypeService;
            _exerciseService = exerciseService;
        }

        public ViewViewComponentResult Invoke()
        {
            FooterViewComponentModel model=new FooterViewComponentModel()
            {
                ExerciseTypes = _exerciseTypeService.GetAll(),
                Exercises = _exerciseService.GetAll(),
                
            };
            return View(model);
        }
    }
}
