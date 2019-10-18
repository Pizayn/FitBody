using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class SupplementDetailsViewModel
    {
        public int Id { get; set; }
        public string SupplementName { get; set; }
        public byte[] Image { get; set; }
        public int UnitPrice { get; set; }
        public string SupplementCategoryName { get; set; }
        public string SupplementSubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Description { get; set; }
    }

    public class SupplementDetailsListViewModel
    {
        public SupplementDetailsViewModel SupplementDetailsViewModel { get; set; }
    }
}
