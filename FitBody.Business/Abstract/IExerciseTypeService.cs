using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
  public  interface IExerciseTypeService
    {
        void Add(ExerciseType exerciseType);
        void Delete(ExerciseType exerciseType);
        void Update(ExerciseType exerciseType);
        List<ExerciseType> GetAll();
    }
}
