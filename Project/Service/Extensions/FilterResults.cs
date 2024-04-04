using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions {
    public class FilterResults {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public int DoctorId { get; set; } = 0;
        public int PatientId { get; set; } = 0;
    }
}
