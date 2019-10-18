using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;

namespace FitBody.WebUI.Model
{
    public class OrderDetailsModel
    {
        public byte[] Image { get; set; }
        public int Price { get; set; }
        public string SupplementName { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public int Total { get; set; }
        public string AccountId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public int SupplementId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Time { get; set; }
    }

    public class OrderDetailsListModel
    {
        public List<OrderDetailsModel> OrderDetailsModels { get; set; }
        public List<Order> Orders { get; set; }
    }
}
