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
   public class ExerciseManager:IExerciseService
   {
       private IExerciseDal _exerciseDal;
        public ExerciseManager(IExerciseDal exerciseDal)
        {
            _exerciseDal = exerciseDal;
        }
        public void Add(Exercise exercise)
        {
           _exerciseDal.Add(exercise);
        }

        public void Delete(Exercise exercise)
        {
           _exerciseDal.Delete(exercise);
        }

        public void Update(Exercise exercise)
        {
            _exerciseDal.Update(exercise);
        }

        public List<Exercise> GetAll()
        {
            return _exerciseDal.GetList();
        }

        public List<Exercise> GetByExerciseId(int exerciseId)
        {
            return _exerciseDal.GetList(x => x.ID == exerciseId);
        }

        public Exercise GetExerciseByExerciseId(int exerciseId)
        {
            return _exerciseDal.Get(x => x.ID == exerciseId);
        }
   }
}
