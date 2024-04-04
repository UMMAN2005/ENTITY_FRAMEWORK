using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Order {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
    }
}
