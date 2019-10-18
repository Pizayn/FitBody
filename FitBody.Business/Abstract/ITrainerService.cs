using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.Business.Abstract
{
   public interface ITrainerService
   {
       void Add(Trainer trainer);
       void Delete(Trainer trainer);
       void Update(Trainer trainer);
       List<Trainer> GetAll();
       Trainer GetTrainerById(int trainerId);
   }
}
