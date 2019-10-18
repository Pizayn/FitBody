using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Entities;

namespace FitBody.WebUI.Model
{
    public class AdminIndexViewModel
    {
        public List<CustomIdentityUser> CustomIdentityContexts { get; set; }
        public List<Supplement> Supplements { get; set; }
        public List<OrderDetailsModel> OrderDetailsModels { get; set; }
        public int UnitInStock { get; set; }
        public int SaleCount { get; set; }
        public int UserCount { get; set; }
        public int BlogPostCount { get; set; }

        
    }
}
