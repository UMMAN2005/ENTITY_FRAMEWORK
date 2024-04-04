using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service.Services {
    public class PatientService {

        private readonly AppDbContext _context;
        public PatientService() { _context = new AppDbContext(); }

        public struct PatientInfo {
            public int Id;
            public string FullName;
            public string Email;
            public int AppointmentCount;
            public DateTime NextAppointmentDate;
        }

        public void Add(Patient patient) {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public Patient? Get(int id) {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public List<Patient> GetAll() {
            return _context.Patients.ToList();
        }

        public List<PatientInfo> SpecialGetAll() {
#pragma warning disable CS8602
            var queryResult = _context.Patients
                .Include(x => x.Appointments)
                .Select(patient => new PatientInfo {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Email = patient.Email,
                    AppointmentCount = patient.Appointments.Count,
                    NextAppointmentDate = patient.Appointments.FirstOrDefault().StartDate
                }).ToList<PatientInfo>();
#pragma warning restore CS8602

            return queryResult;
        }

        public void Update(int id, Patient patient) {
            Patient? oldPatient = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");
            oldPatient.FullName = patient.FullName;
            oldPatient.Email = patient.Email;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Patient? patient = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
