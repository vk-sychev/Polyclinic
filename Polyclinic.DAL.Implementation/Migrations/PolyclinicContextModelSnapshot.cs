﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Polyclinic.DAL.Implementation.EF;

namespace Polyclinic.DAL.Implementation.Migrations
{
    [DbContext(typeof(PolyclinicContext))]
    partial class PolyclinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Polyclinic.DAL.Entities.Cabinet", b =>
                {
                    b.Property<int>("CabinetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CabinetNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("CabinetId");

                    b.ToTable("Cabinets");

                    b.HasData(
                        new
                        {
                            CabinetId = 1,
                            CabinetNumber = 228
                        },
                        new
                        {
                            CabinetId = 2,
                            CabinetNumber = 320
                        },
                        new
                        {
                            CabinetId = 3,
                            CabinetNumber = 223
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.CabinetInfo", b =>
                {
                    b.Property<int>("CabinetInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CabinetId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.HasKey("CabinetInfoId");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DoctorId");

                    b.ToTable("CabinetInfos");

                    b.HasData(
                        new
                        {
                            CabinetInfoId = 1,
                            CabinetId = 1,
                            DateEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStart = new DateTime(2019, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1
                        },
                        new
                        {
                            CabinetInfoId = 2,
                            CabinetId = 2,
                            DateEnd = new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStart = new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2
                        },
                        new
                        {
                            CabinetInfoId = 3,
                            CabinetId = 3,
                            DateEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStart = new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2
                        },
                        new
                        {
                            CabinetInfoId = 4,
                            CabinetId = 2,
                            DateEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStart = new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Diagnosis", b =>
                {
                    b.Property<int>("DiagnosisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("DiagnosisId");

                    b.ToTable("Diagnoses");

                    b.HasData(
                        new
                        {
                            DiagnosisId = 1,
                            Description = "Needs careful treatment",
                            Name = "Diabetes"
                        },
                        new
                        {
                            DiagnosisId = 2,
                            Description = "Nothing serious, just avoid much coffee",
                            Name = "Tachycardia"
                        },
                        new
                        {
                            DiagnosisId = 3,
                            Description = "Outflow of blood from the head is disturbed",
                            Name = "Headache"
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.DiagnosisInfo", b =>
                {
                    b.Property<int>("DiagnosisInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DiagnosisId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("DiagnosisInfoId");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("PatientId");

                    b.ToTable("DiagnosisInfos");

                    b.HasData(
                        new
                        {
                            DiagnosisInfoId = 1,
                            DiagnosisId = 1,
                            PatientId = 1
                        },
                        new
                        {
                            DiagnosisInfoId = 2,
                            DiagnosisId = 2,
                            PatientId = 2
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LicenseNumber")
                        .HasColumnType("text");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("DoctorId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UserId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            LicenseNumber = "1111",
                            SpecialtyId = 1,
                            UserId = 1
                        },
                        new
                        {
                            DoctorId = 2,
                            LicenseNumber = "2222",
                            SpecialtyId = 2,
                            UserId = 2
                        },
                        new
                        {
                            DoctorId = 3,
                            LicenseNumber = "3333",
                            SpecialtyId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Policy")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PatientId");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = 1,
                            Policy = "12321",
                            UserId = 4
                        },
                        new
                        {
                            PatientId = 2,
                            Policy = "213214",
                            UserId = 5
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");

                    b.HasData(
                        new
                        {
                            SpecialtyId = 1,
                            Name = "Endocrinologist"
                        },
                        new
                        {
                            SpecialtyId = 2,
                            Name = "Сardiologist"
                        },
                        new
                        {
                            SpecialtyId = 3,
                            Name = "Therapist"
                        },
                        new
                        {
                            SpecialtyId = 4,
                            Name = "Neurologist"
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PassportData")
                        .HasColumnType("text");

                    b.Property<string>("Snills")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            BornDate = new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andrey",
                            PassportData = "2020445765",
                            Snills = "1234",
                            Surname = "Solovyev"
                        },
                        new
                        {
                            UserId = 2,
                            BornDate = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Vasiliy",
                            PassportData = "2020123987",
                            Snills = "2345",
                            Surname = "Sychev"
                        },
                        new
                        {
                            UserId = 3,
                            BornDate = new DateTime(2000, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ivan",
                            PassportData = "2020234765",
                            Snills = "3456",
                            Surname = "Tkachenko"
                        },
                        new
                        {
                            UserId = 4,
                            BornDate = new DateTime(2001, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ivan",
                            PassportData = "2014456765",
                            Snills = "4567",
                            Surname = "Menshih"
                        },
                        new
                        {
                            UserId = 5,
                            BornDate = new DateTime(2000, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lev",
                            PassportData = "2020567123",
                            Snills = "6789",
                            Surname = "Makeev"
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Complaint")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateVisit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("VisitId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            VisitId = 1,
                            DateVisit = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            PatientId = 1,
                            Price = 1300.0
                        },
                        new
                        {
                            VisitId = 2,
                            Complaint = "Too expensive",
                            DateVisit = new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2,
                            PatientId = 1,
                            Price = 1000.0
                        },
                        new
                        {
                            VisitId = 3,
                            DateVisit = new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            PatientId = 2,
                            Price = 1200.0
                        });
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.CabinetInfo", b =>
                {
                    b.HasOne("Polyclinic.DAL.Entities.Cabinet", "Cabinet")
                        .WithMany("CabinetInfos")
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polyclinic.DAL.Entities.Doctor", "Doctor")
                        .WithMany("CabinetInfos")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.DiagnosisInfo", b =>
                {
                    b.HasOne("Polyclinic.DAL.Entities.Diagnosis", "Diagnosis")
                        .WithMany("DiagnosisInfos")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polyclinic.DAL.Entities.Patient", "Patient")
                        .WithMany("DiagnosisInfos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnosis");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Doctor", b =>
                {
                    b.HasOne("Polyclinic.DAL.Entities.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polyclinic.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Patient", b =>
                {
                    b.HasOne("Polyclinic.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Visit", b =>
                {
                    b.HasOne("Polyclinic.DAL.Entities.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Polyclinic.DAL.Entities.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Cabinet", b =>
                {
                    b.Navigation("CabinetInfos");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Diagnosis", b =>
                {
                    b.Navigation("DiagnosisInfos");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Doctor", b =>
                {
                    b.Navigation("CabinetInfos");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Polyclinic.DAL.Entities.Patient", b =>
                {
                    b.Navigation("DiagnosisInfos");

                    b.Navigation("Visits");
                });
#pragma warning restore 612, 618
        }
    }
}
