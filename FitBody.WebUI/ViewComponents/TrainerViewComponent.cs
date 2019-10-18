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
    public class TrainerViewComponent: ViewComponent
    {
        private ITrainerService _trainerService;

        public TrainerViewComponent(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public ViewViewComponentResult Invoke()
        {
            TrainerListViewModel trainerListViewModel = new TrainerListViewModel()
            {
                Trainers = _trainerService.GetAll(),
            };
            return View(trainerListViewModel);
        }
    }
}
