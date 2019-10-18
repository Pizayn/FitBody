using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.DataAccess.Abstract;
using FitBody.Entities.Concrete;

namespace FitBody.DataAccess.Concrete
{
    public class ExerciseDal:Repository<Exercise, FitBodyContext>,IExerciseDal
    {

    }
}
