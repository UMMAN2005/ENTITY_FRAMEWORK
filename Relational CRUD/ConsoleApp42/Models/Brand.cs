using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp42.Models;

namespace ConsoleApp42.Models {
    public class Brand {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalValue { get; set; }
        public List<Product> Products { get; set; }
    }
}
