using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations {
    public class PatientConfiguration : IEntityTypeConfiguration<Patient> {
        public void Configure(EntityTypeBuilder<Patient> builder) {

        }
    }
}
