using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Entities;
using FitBody.WebUI.Model;
using FitBody.WebUI.Model.AddViewModel;
using FitBody.WebUI.Model.EditViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Linq;

namespace FitBody.WebUI.Controller
{
  
    [Authorize(Roles ="Admin")]
    public class AdminController : Microsoft.AspNetCore.Mvc.Controller
    {
        private IExerciseService _exerciseService;
        private IExerciseTypeService _exerciseTypeService;
        private ISupplementCategoryService _supplementCategoryService;
        private ISupplementService _supplementService;
        private ISupplementSubCategoryService _supplementSubCategoryService;
        private ITrainerService _trainerService;
        private IBlogPostService _blogPostService;
        private CustomIdentityContext _customIdentityContext;
        private IOrderLineService _orderLineService;
        private IHostingEnvironment _hostingEnvironment;
        private UserManager<CustomIdentityUser> _userManager;

        public AdminController(IExerciseService exerciseService, IExerciseTypeService exerciseTypeService, IHostingEnvironment hostingEnvironment, ISupplementCategoryService supplementCategoryService, ISupplementService supplementService, ISupplementSubCategoryService supplementSubCategoryService, ITrainerService trainerService, IBlogPostService blogPostService, UserManager<CustomIdentityUser> userManager, CustomIdentityContext customIdentityContext, IOrderLineService orderLineService)
        {
            _exerciseService = exerciseService;
            _exerciseTypeService = exerciseTypeService;
            _hostingEnvironment = hostingEnvironment;
            _supplementCategoryService = supplementCategoryService;
            _supplementService = supplementService;
            _supplementSubCategoryService = supplementSubCategoryService;
            _trainerService = trainerService;
            _blogPostService = blogPostService;
            _userManager = userManager;
            _customIdentityContext = customIdentityContext;
            _orderLineService = orderLineService;
        }

        public IActionResult Index()
        {
            
            FitBodyContext context=new FitBodyContext();
            var details = from supplement in context.Supplements
                join orderline in context.OrderLines on supplement.ID equals orderline.SupplementID
                select new OrderDetailsModel()
                {
                    SupplementName = supplement.SupplementName,
                    Price = orderline.Price,
                    Quantity = orderline.Quantity,
                    Id = orderline.ID,
                    Time = orderline.Time
                };
           AdminIndexViewModel model=new AdminIndexViewModel()
           {
               CustomIdentityContexts = _customIdentityContext.Users.ToList(),
               Supplements = _supplementService.GetAll(),
               OrderDetailsModels = details.OrderByDescending(x=>x.Name).ThenBy(x=>x.Time).ToList(),
               UnitInStock = _supplementService.GetAllUnitInStock(),
               SaleCount = _orderLineService.GetAllSaleCount(),
               UserCount = _customIdentityContext.Users.Count(),
               BlogPostCount = _blogPostService.GetBlogPostCount(),
           };
            return View(model);
        }

         [HttpPost]
        public IActionResult Index(BlogPost blogPost)
        {
            //Operation
            return View();
        }

     
        public IActionResult Supplement()
        {
            AdminSupplementViewModel supplementViewModel=new AdminSupplementViewModel()
            {
                Supplements = _supplementService.GetAll(),
            };
            return View(supplementViewModel);
        }

        public IActionResult Exercise()
        {
            ExerciseViewModel model=new ExerciseViewModel()
            {
                Exercises = _exerciseService.GetAll(),
                ExerciseTypes = _exerciseTypeService.GetAll(),

            };
            return View(model);
        }

        
        public IActionResult ExerciseAdd()
        {
           ExerciseAddViewModel exerciseAddViewModel=new ExerciseAddViewModel
           {
               Exercise = new Exercise(),
               ExerciseTypes = _exerciseTypeService.GetAll()
          };
            
            return View(exerciseAddViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseAdd(Exercise exercise)
        {
            

            if (ModelState.IsValid)
            {
              _exerciseService.Add(exercise);
              TempData.Add("message","Exercise succesfully  added");
              return RedirectToAction("ExerciseAdd");
            }
            else
            {
                TempData.Add("message","Exercise not added Please Try Again");
                ExerciseAddViewModel exerciseAddViewModel=new ExerciseAddViewModel
                {
                    Exercise = exercise,
                    ExerciseTypes = _exerciseTypeService.GetAll()
                };
                return View(exerciseAddViewModel);
            }

         
        }

       
        public IActionResult ExerciseTypeAdd()
        {
            ExerciseTypeAddViewModel exerciseTypeViewModel=new ExerciseTypeAddViewModel
            {
                ExerciseType = new ExerciseType()
            };
            return View(exerciseTypeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseTypeAdd(ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                _exerciseTypeService.Add(exerciseType);
                TempData.Add("message", "Exercise Type successfully added");
                return RedirectToAction("ExerciseTypeAdd");
            }
            else
            {
                TempData.Add("message","Exercise Type is not add");
                return View();
            }
           

        }

        [Route("admin/SupplementCategory/Add")]
        public IActionResult SupplementCategoryAdd()
        {
            SupplementCategoryAddViewModel  supplementCategoryAddViewModel = new SupplementCategoryAddViewModel()
            {
                SupplementCategory = new SupplementCategory()
            };
            return View(supplementCategoryAddViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SupplementCategoryAdd(SupplementCategory  supplementCategory)
        {
            if (ModelState.IsValid)
            {
                _supplementCategoryService.Add(supplementCategory);
                TempData.Add("message", "Supplement Category  successfully added");
                return RedirectToAction("SupplementCategoryAdd");
            }
            else
            {
                TempData.Add("message", "Supplement Category   not added");
                return View();
            }


        }

        [Route("admin/SupplementSubCategoryAdd/Add")]
        public IActionResult SupplementSubCategoryAdd()
        {
            SupplementSubCategoryAddViewModel  supplementSubCategoryAddViewModel = new SupplementSubCategoryAddViewModel()
            {
                SupplementCategory = _supplementCategoryService.GetAll(),
                SupplementSubCategory = new SupplementSubCategory()

            };
            return View(supplementSubCategoryAddViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SupplementCategoryAdd(SupplementSubCategory supplementSubCategory)
        {
            if (ModelState.IsValid)
            {
                _supplementSubCategoryService.Add(supplementSubCategory);
                TempData.Add("message", "Supplement Sub Category  successfully added");
                return RedirectToAction("SupplementSubCategoryAdd");
            }
            else
            {
                TempData.Add("message", "Supplement Sub Category  not added");
                return View();
            }


        }

        
        public IActionResult SupplementAdd()
        {
            SupplementAddVİewModel supplementAddVIewModel =new SupplementAddVİewModel
            {
                Supplement = new Supplement(),
                SupplementSubCategories = _supplementSubCategoryService.GetAll(),
                SupplementCategories = _supplementCategoryService.GetAll(),
            };

            return View(supplementAddVIewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplementAdd(Supplement supplement,IFormFile formFile)
        {
            supplement.Time = DateTime.Today;
            if (formFile .Length==0 && formFile==null)
            {
                TempData.Add("message","Image not selected");
                return RedirectToAction("SupplementAdd");
            }
            else
            {

                using (var stream = new MemoryStream())
                {
                    await formFile.CopyToAsync(stream);
                    supplement.Image = stream.ToArray();

                }

            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
               
                _supplementService.Add(supplement);
                TempData.Add("message","Supplement successfully added");
                return RedirectToAction("SupplementAdd");
            }
            else
            {
                TempData.Add("message", "Supplement not added");
                SupplementAddVİewModel supplementAddVIewModel=new SupplementAddVİewModel
                {
                    Supplement = supplement,
                    SupplementSubCategories = _supplementSubCategoryService.GetAll(),
                    SupplementCategories = _supplementCategoryService.GetAll()

                };
                return View(supplementAddVIewModel);

            }
           
        }

       
        public IActionResult ExerciseEdit(int exerciseId)
        {
            ExerciseEditVİewModel editVIewModel=new ExerciseEditVİewModel
            {
                Exercise = _exerciseService.GetExerciseByExerciseId(exerciseId),
                ExerciseTypes = _exerciseTypeService.GetAll(),
            };

            return View(editVIewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExerciseEdit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _exerciseService.Update(exercise);
                TempData.Add("message", "Exercise successfully updated");
            }
            return RedirectToAction("Index");


        }

       
        public IActionResult SupplementEdit(int supplementId)
        {
            SupplementEditViewModel supplementEditViewModel=new SupplementEditViewModel
            {
                Supplement = _supplementService.GetSupplementById(supplementId),
                SupplementSubCategories = _supplementSubCategoryService.GetAll(),
                SupplementCategories = _supplementCategoryService.GetAll(),
            };
            return View(supplementEditViewModel);
        }

        [HttpPost]
        public IActionResult SupplementEdit(Supplement supplement)
        {
            if (ModelState.IsValid)
            {
                _supplementService.Update(supplement);
                TempData.Add("message","Supplement successfully updated ");
            }
            return RedirectToAction("Supplement");


        }

        public IActionResult ExerciseDelete(Exercise exercise)
        {
            _exerciseService.Delete(exercise);
            return RedirectToAction("Index");
        }
        public IActionResult ExerciseTypeDelete(ExerciseType exerciseType)
        {
            _exerciseTypeService.Delete(exerciseType);
            return RedirectToAction("Index");
        }
        public IActionResult SupplementDelete(Supplement supplement)
        {
            _supplementService.Delete(supplement);
            return RedirectToAction("Index");
        }
        public IActionResult SupplementCategoryDelete(SupplementCategory supplementCategory)
        {
            _supplementCategoryService.Delete(supplementCategory);
            return RedirectToAction("Index");
        }
        public IActionResult SupplementSubCategoryDelete(SupplementSubCategory supplementSubCategory)
        {
            _supplementSubCategoryService.Delete(supplementSubCategory);
            return RedirectToAction("Index");
        }

        public IActionResult TrainerAdd()
        {
            TrainerAddViewModel trainerAddViewModel=new TrainerAddViewModel()
            {
                Trainer = new Trainer()
            };

            return View(trainerAddViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrainerAdd(Trainer trainer,IFormFile formFile)
        {
            if (formFile.Length==0 &&  formFile==null)
            {
                TempData.Add("message","Image not selected");
                return RedirectToAction("TrainerAdd");
            }
            else
            {
                using (var stream = new MemoryStream())
                {
                 await  formFile.CopyToAsync(stream);
                 trainer.Image = stream.ToArray();
                }
               

            }
            if (ModelState.IsValid)
            {
               
                _trainerService.Add(trainer);
                TempData.Add("message","Trainer successfully added");
                return RedirectToAction("TrainerAdd");
            }
            else
            {
                TrainerAddViewModel trainerAddViewModel=new TrainerAddViewModel()
                {
                    Trainer = trainer
                };
                TempData.Add("message","Trainer not added");
            }
            return View();
        }

        public IActionResult Trainer()
        {
            TrainerListViewModel trainerListViewModel=new TrainerListViewModel()
            {
                Trainers = _trainerService.GetAll(),
            };
            return View(trainerListViewModel);
        }
       
        public IActionResult TrainerEdit(int trainerId)
        {
            TrainerEditViewModel trainerEditViewModel = new TrainerEditViewModel()
            {
              Trainer = _trainerService.GetTrainerById(trainerId),
               
            };
            return View(trainerEditViewModel);
        }

        [HttpPost]
        public IActionResult TrainerEdit(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                _trainerService.Update(trainer);
                TempData.Add("message", "Trainer successfully updated ");
            }
            return RedirectToAction("Trainer");


        }

        public IActionResult TrainerDelete(Trainer trainer)
        {
            _trainerService.Delete(trainer);
            return RedirectToAction("Trainer");
        }

        public IActionResult BlogPost()
        {
            BlogViewModel blogViewModel=new BlogViewModel()
            {
                BlogPosts = _blogPostService.GetAll()
            };
            return View(blogViewModel);
        }

        public IActionResult BlogPostAdd()
        {
            BlogViewModel blogViewModel=new BlogViewModel()
            {
                BlogPost =new BlogPost()
            };
            return View(blogViewModel);
        }

        [HttpPost]
        public IActionResult BlogPostAdd(BlogPost blogPost)
        {
            blogPost.Time = DateTime.Today;
            blogPost.AccountId = _userManager.GetUserId(HttpContext.User);

            
                
                _blogPostService.Add(blogPost);
            

            return RedirectToAction("Index", "News");
        }

        public IActionResult BlogPostEdit(int blogId)
        {
            BlogPostEditViewModel blogPostEditViewModel=new BlogPostEditViewModel()
            {
                BlogPost = _blogPostService.GetByBlogPostId(blogId),
            };

            return View(blogPostEditViewModel);
        }
        [HttpPost]
        public IActionResult BlogPostEdit(BlogPost blogPost)
        {
            
            _blogPostService.Update(blogPost);
            TempData.Add("message","News successfully updated");
            return RedirectToAction("Index", "News");
        }

        public IActionResult BlogPostDelete(BlogPost blogPost)
        {
            _blogPostService.Delete(blogPost);
            TempData.Add("message", "News successfully deleted");
            return RedirectToAction("BlogPost", "Admin");
        }





    }

    
}