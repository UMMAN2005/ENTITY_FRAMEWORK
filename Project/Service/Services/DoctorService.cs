using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service.Services {
    public class DoctorService {

        private readonly AppDbContext _context;
        public DoctorService() { _context = new AppDbContext(); }

        public struct DoctorInfo {
            public int Id;
            public string FullName;
            public string Email;
            public int AppointmentCount;
        }

        public void Add(Doctor doctor) {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public Doctor? Get(int id) {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public List<Doctor> GetAll() {
            return _context.Doctors.ToList();
        }

        public List<DoctorInfo> SpecialGetAll () {
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;

            var queryResult = _context.Doctors
                .Include(d => d.Appointments)
                .Select(doctor => new DoctorInfo {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    Email = doctor.Email,
                    AppointmentCount = doctor.Appointments
                        .Where(appointment => appointment.StartDate > now && appointment.StartDate.Date == today)
                        .Count()
                }).ToList<DoctorInfo>();

            return queryResult;
        }


        public void Update(int id, Doctor doctor) {
            Doctor? oldDoctor = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");
            oldDoctor.FullName = doctor.FullName;
            oldDoctor.Email = doctor.Email;
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Doctor? doctor = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
