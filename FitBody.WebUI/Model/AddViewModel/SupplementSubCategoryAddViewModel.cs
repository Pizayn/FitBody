using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class SupplementSubCategoryAddViewModel
    {
        public List<SupplementCategory> SupplementCategory { get; set; }
        public SupplementSubCategory SupplementSubCategory { get; set; }
    }
}
