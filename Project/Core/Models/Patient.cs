﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models {
    public class Patient {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; }

        public override string ToString() {
            return $"Id: {Id}, FullName: {FullName}, Email: {Email}";
        }
    }
}
