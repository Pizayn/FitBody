using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
  public  interface IExerciseService
  {
      void Add(Exercise exercise);
      void Delete(Exercise exercise);
      void Update(Exercise exercise);
      List<Exercise> GetAll();
      List<Exercise> GetByExerciseId(int exerciseId);

      Exercise GetExerciseByExerciseId(int exerciseId);
  }
}
