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
   public class TrainerManager:ITrainerService
   {
       private ITrainerDal _trainerDal;

       public TrainerManager(ITrainerDal trainerDal)
       {
           _trainerDal = trainerDal;
       }

       public void Add(Trainer trainer)
        {
            _trainerDal.Add(trainer);
        }

        public void Delete(Trainer trainer)
        {
           
            _trainerDal.Delete(trainer);
        }

        public void Update(Trainer trainer)
        {
           
            _trainerDal.Update(trainer);
        }

        public List<Trainer> GetAll()
        {

            return _trainerDal.GetList();
        }

        public Trainer GetTrainerById(int trainerId)
        {
            return _trainerDal.Get(x => x.ID == trainerId);
        }
    }
}
