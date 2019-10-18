using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FitBody.WebUI.Controller
{
    public class TrainerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public IActionResult Index()
        {
            TrainerListViewModel trainerListViewModel=new TrainerListViewModel()
            {
                Trainers = _trainerService.GetAll(),
            };
            return View(trainerListViewModel);
        }
    }
}