using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data;
using Service.Exceptions;
using Service.Extensions;

namespace Service.Services {
    public class AppointmentService {

        private readonly AppDbContext _context;
        private const int MINUTES_BETWEEN_APPOINTMENTS = 30;
        public AppointmentService() { _context = new AppDbContext();}

        public void Add(Appointment appointment) {
            if (!_context.Doctors.Any(x => x.Id == appointment.DoctorId))
                throw new EntityNotFoundException("Doctor not found.");
            if (!_context.Patients.Any(x => x.Id == appointment.PatientId))
                throw new EntityNotFoundException("Patient not found");

            if (GetAll().Any(x => x.DoctorId == appointment.DoctorId &&
                                  x.StartDate.AddMinutes(MINUTES_BETWEEN_APPOINTMENTS) > appointment.StartDate && 
                                  x.StartDate < appointment.StartDate))
                throw new IsBusyException("Doctor is busy");

            if (GetAll().Any(x => x.DoctorId == appointment.DoctorId && x.StartDate > appointment.StartDate))
                throw new PastTimeException("Doctor has newer appointments!");

            if (GetAll().Any(x => x.PatientId == appointment.PatientId &&
                                  x.StartDate.AddMinutes(MINUTES_BETWEEN_APPOINTMENTS) > appointment.StartDate &&
                                  x.StartDate < appointment.StartDate))
                throw new IsBusyException("Patient is busy");

            if (GetAll().Any(x => x.PatientId == appointment.PatientId && x.StartDate > appointment.StartDate))
                throw new PastTimeException("Patient has newer appointments!");

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }


        public Appointment? Get(int id) {
            return _context.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public List<Appointment> GetAll() {
            return _context.Appointments.ToList();
        }

        public List<Appointment> FilterAppointments(FilterResults filterResults) {
            var query = _context.Appointments.AsQueryable();

            if (filterResults.StartDate != DateTime.MinValue)
                query = query.Where(a => a.StartDate >= filterResults.StartDate);

            if (filterResults.EndDate != DateTime.MaxValue)
                query = query.Where(a => a.StartDate <= filterResults.EndDate);

            if (filterResults.DoctorId != 0)
                query = query.Where(a => a.DoctorId == filterResults.DoctorId);

            if (filterResults.PatientId != 0)
                query = query.Where(a => a.PatientId == filterResults.PatientId);

            return query.ToList();
        }
        public void Update(int id, Appointment appointment) {
            Appointment? oldAppointment = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");

            if (!_context.Doctors.Any(x => x.Id == appointment.DoctorId))
                throw new EntityNotFoundException("Doctor not found.");

            if (!_context.Patients.Any(x => x.Id == appointment.PatientId))
                throw new EntityNotFoundException("Patient not found");

            if (GetAll().Any(x => x.DoctorId == appointment.DoctorId &&
                                  x.StartDate.AddMinutes(MINUTES_BETWEEN_APPOINTMENTS) > appointment.StartDate &&
                                  x.StartDate < appointment.StartDate &&
                                  x.Id != id))
                throw new IsBusyException("Doctor is busy");

            if (GetAll().Any(x => x.StartDate > appointment.StartDate && x.Id != id))
                throw new PastTimeException("Doctor has newer appointments!");

            if (GetAll().Any(x => x.PatientId == appointment.PatientId &&
                                  x.StartDate.AddMinutes(MINUTES_BETWEEN_APPOINTMENTS) > appointment.StartDate &&
                                  x.StartDate < appointment.StartDate &&
                                  x.Id != id))
                throw new IsBusyException("Patient is busy");

            if (GetAll().Any(x => x.PatientId == appointment.PatientId && x.StartDate > appointment.StartDate && x.Id != id))
                throw new PastTimeException("Patient has newer appointments!");

            oldAppointment.DoctorId = appointment.DoctorId;
            oldAppointment.PatientId = appointment.PatientId;
            oldAppointment.StartDate = appointment.StartDate;

            _context.SaveChanges();
        }


        public void Delete(int id) {
            Appointment? appointment = Get(id) ?? throw new EntityNotFoundException("Appointment not found.");
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
