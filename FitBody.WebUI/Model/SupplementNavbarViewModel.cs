using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class SupplementNavbarViewModel
    {
        public List<SupplementCategory> SupplementCategories { get; set; }
        public List<SupplementSubCategory> SupplementSubCategories { get; set; }
    }
}
