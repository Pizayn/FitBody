using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model.EditViewModel
{
    public class SupplementEditViewModel
    {
        public Supplement Supplement { get; set; }
        public List<SupplementCategory> SupplementCategories { get; set; }
        public List<SupplementSubCategory> SupplementSubCategories { get; set; }
    }
}
