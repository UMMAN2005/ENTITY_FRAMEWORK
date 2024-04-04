using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Models {
    public class Product {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Order> Orders { get; set; }

    }
}
