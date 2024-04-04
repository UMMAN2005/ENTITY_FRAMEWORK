using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class AppDbContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=DELL-UMMAN\\SQLEXPRESS;Database=Hospital;Trusted_Connection=True;TrustServerCertificate=True");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
        }
    }
}
