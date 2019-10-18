using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBody.Entities.Concrete
{
    public class CartLine
    {
        public int Quantity { get; set; }
        public Supplement Supplement { get; set; }
    }
}
