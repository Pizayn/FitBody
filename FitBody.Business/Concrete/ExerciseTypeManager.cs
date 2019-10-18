using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Concrete
{
   public class ExerciseTypeManager:IExerciseTypeService
   {
       private IExerciseTypeDal  _exerciseTypeDal;

       public ExerciseTypeManager(IExerciseTypeDal exerciseTypeDal)
       {
           _exerciseTypeDal = exerciseTypeDal;
           
       }

       public void Add(ExerciseType exerciseType)
        {
            _exerciseTypeDal.Add(exerciseType);
        }

        public void Delete(ExerciseType exerciseType)
        {
            _exerciseTypeDal.Delete(exerciseType);
        }

        public void Update(ExerciseType exerciseType)
        {
            _exerciseTypeDal.Update(exerciseType);
        }

        public List<ExerciseType> GetAll()
        {
            return _exerciseTypeDal.GetList();
        }
   }
}
