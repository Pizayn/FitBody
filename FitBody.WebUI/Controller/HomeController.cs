using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Linq;

namespace FitBody.WebUI.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IExerciseService _exerciseService;
        private IExerciseTypeService _exerciseTypeService;
        private ITrainerService _trainerService;
        private IBlogPostService _blogPostService;
        private SignInManager<CustomIdentityUser> _signInManager;

        public HomeController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService, SignInManager<CustomIdentityUser> signInManager, ITrainerService trainerService, IBlogPostService blogPostService)
        {
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
            _signInManager = signInManager;
            _trainerService = trainerService;
            _blogPostService = blogPostService;
        }
        
    
        public IActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel()
            {
                Exercises = _exerciseService.GetAll(),
                Trainers = _trainerService.GetAll(),
                ExerciseTypes = _exerciseTypeService.GetAll(),
                BlogPosts = _blogPostService.GetAll().OrderBy(x=>x.Time.Day).ToList(),
            };
           




            return View(homeViewModel);
        }

        
    }
}