using Microsoft.EntityFrameworkCore;
using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.DAL.Implementation.EF
{
    public class PolyclinicContext : DbContext
    {
        public PolyclinicContext(DbContextOptions<PolyclinicContext> options) : base(options) { }

        public DbSet<Cabinet> Cabinets { get; set; }

        public DbSet<CabinetInfo> CabinetInfos { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<DiagnosisInfo> DiagnosisInfos { get; set; }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<Patient>()
                .Property<int>("UserId");

            modelBuilder.Entity<Patient>()
                .HasOne(x => x.User)
                .Has*/

            modelBuilder.Entity<Visit>()
                .Property(x => x.Complaint)
                .IsRequired(false);

            modelBuilder.Entity<Cabinet>()
                .Property(x => x.Description)
                .IsRequired(false);

            modelBuilder.Entity<Specialty>()
                .Property(x => x.Description)
                .IsRequired(false);

/*            modelBuilder.Entity<CabinetInfo>()
                .Property(x => x.DateEnd)
                .IsRequired(false);*/

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
/*            modelBuilder.Entity<CabinetInfo>()
                .HasOne(x => x.Cabinet)
                .WithMany(x => x.CabinetInfos);

            modelBuilder.Entity<CabinetInfo>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.CabinetInfos);*/
        }
    }
}
