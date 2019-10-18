using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Entities.Concrete
{
  public  class Cart
    {
        public Cart()
        {
           CartLines=new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }

        public int Total
        {
            get { return CartLines.Sum(c => c.Supplement.Price*c.Quantity); }
        }
    }
}
