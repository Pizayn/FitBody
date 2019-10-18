using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class SupplementListViewModel
    {
        public List<Supplement> Supplements { get; set; }
        public int CurrentCategory { get; set; }
        public int CurrentSubCategory { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string CurrentAction { get; set; }
        public int PageCount { get; set; }
    }
}
