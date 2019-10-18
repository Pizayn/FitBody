using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitBody.WebUI.Model
{
    public class DropdownModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }

    public class DropdownListModel
    {
        public List<DropdownModel> DropdownModels { get; set; }
    }
}
