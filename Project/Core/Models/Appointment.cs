using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Appointment {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public override string ToString() {
            return $"Id: {Id}, StartDate: {StartDate}, DoctorId: {DoctorId}, PatientId: {PatientId}";
        }
    }
}
