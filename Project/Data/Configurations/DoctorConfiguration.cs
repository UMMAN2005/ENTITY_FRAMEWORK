using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configurations {
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor> {
        public void Configure(EntityTypeBuilder<Doctor> builder) {

        }
    }
}
