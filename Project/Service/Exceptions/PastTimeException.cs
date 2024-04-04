using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions {
    public class PastTimeException : Exception {
        public PastTimeException(string message) : base(message) { }
    }
}
