using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPPINGCART.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
