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

        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Visit>()
                .Property(x => x.Complaint)
                .IsRequired(false);

            modelBuilder.Entity<Cabinet>()
                .Property(x => x.Description)
                .IsRequired(false);

            modelBuilder.Entity<Specialty>()
                .Property(x => x.Description)
                .IsRequired(false);


            modelBuilder.Entity<Doctor>()
                .HasMany(t => t.Cabinets)
                .WithMany(s => s.Doctors)

                .UsingEntity<CabinetInfo>(
                    j => j.HasOne(tr => tr.Cabinet)
                        .WithMany(t => t.CabinetInfos)
                        .HasForeignKey(tr => tr.CabinetId),

                    j => j.HasOne(tr => tr.Doctor)
                        .WithMany(s => s.CabinetInfos)
                        .HasForeignKey(tr => tr.DoctorId),

                    j => j.HasKey(tr => tr.CabinetInfoId)
                );

            modelBuilder.Entity<Patient>()
                .HasMany(t => t.Diagnoses)
                .WithMany(s => s.Patients)

                .UsingEntity<DiagnosisInfo>(
                    j => j.HasOne(tr => tr.Diagnosis)
                        .WithMany(s => s.DiagnosisInfos)
                        .HasForeignKey(tr => tr.DiagnosisId),

                    j => j.HasOne(tr => tr.Patient)
                        .WithMany(t => t.DiagnosisInfos)
                        .HasForeignKey(tr => tr.PatientId),

                    j => j.HasKey(tr => tr.DiagnosisInfoId)
                );


            modelBuilder.Entity<Patient>()
                .HasMany(t => t.Doctors)
                .WithMany(s => s.Patients)

                .UsingEntity<Visit>(
                    j => j.HasOne(tr => tr.Doctor)
                        .WithMany(s => s.Visits)
                        .HasForeignKey(tr => tr.DoctorId),

                    j => j.HasOne(tr => tr.Patient)
                        .WithMany(t => t.Visits)
                        .HasForeignKey(tr => tr.PatientId),

                    j => j.HasKey(tr => tr.VisitId)
                );


            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

        }
    }
}
