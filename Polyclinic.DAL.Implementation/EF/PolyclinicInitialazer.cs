using Microsoft.EntityFrameworkCore;
using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.DAL.Implementation.EF
{
    public static class PolyclinicInitialazer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var user1 = new User()
            {
                UserId = 1,
                Name = "Andrey",
                Surname = "Solovyev",
                BornDate = new DateTime(2000, 04, 03),
                PassportData = "2020445765",
                Snills = "1234"
            };

            var user2 = new User()
            {
                UserId = 2,
                Name = "Vasiliy",
                Surname = "Sychev",
                BornDate = new DateTime(2000, 10, 10),
                PassportData = "2020123987",
                Snills = "2345"
            };

            var user3 = new User()
            {
                UserId = 3,
                Name = "Ivan",
                Surname = "Tkachenko",
                BornDate = new DateTime(2000, 04, 07),
                PassportData = "2020234765",
                Snills = "3456"
            };

            var user4 = new User()
            {
                UserId = 4,
                Name = "Ivan",
                Surname = "Menshih",
                BornDate = new DateTime(2001, 8, 14),
                PassportData = "2014456765",
                Snills = "4567"
            };

            var user5 = new User()
            {
                UserId = 5,
                Name = "Lev",
                Surname = "Makeev",
                BornDate = new DateTime(2000, 07, 24),
                PassportData = "2020567123",
                Snills = "6789"
            };

            modelBuilder.Entity<User>().HasData(user1, user2, user3, user4, user5);



            var specialty1 = new Specialty()
            {
                SpecialtyId = 1,
                Name = "Endocrinologist"
            };

            var specilaty2 = new Specialty()
            {
                SpecialtyId = 2,
                Name = "Сardiologist"
            };

            var specialty3 = new Specialty()
            {
                SpecialtyId = 3,
                Name = "Therapist"
            };

            var specilaty4 = new Specialty()
            {
                SpecialtyId = 4,
                Name = "Neurologist"
            };

            modelBuilder.Entity<Specialty>().HasData(specialty1, specilaty2, specialty3, specilaty4);



            var doctor1 = new Doctor()
            {
                DoctorId = 1,
                UserId = user1.UserId,
                SpecialtyId = specialty1.SpecialtyId,
                LicenseNumber = "1111"
            };

            var doctor2 = new Doctor()
            {
                DoctorId = 2,
                UserId = user2.UserId,
                SpecialtyId = specilaty2.SpecialtyId,
                LicenseNumber = "2222"
            };

            var doctor3 = new Doctor()
            {
                DoctorId = 3,
                UserId = user3.UserId,
                SpecialtyId = specialty3.SpecialtyId,
                LicenseNumber = "3333"
            };

            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2, doctor3);


            var patient1 = new Patient()
            {
                PatientId = 1,
                Policy = "12321",
                UserId = user4.UserId
            };

            var patient2 = new Patient()
            {
                PatientId = 2,
                Policy = "213214",
                UserId = user5.UserId
            };


            modelBuilder.Entity<Patient>().HasData(patient1, patient2);


            var visit1 = new Visit()
            {
                VisitId = 1,
                PatientId = patient1.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 02, 02),
                Price = 1300
            };

            var visit2 = new Visit()
            {
                VisitId = 2,
                PatientId = patient1.PatientId,
                DoctorId = doctor2.DoctorId,
                DateVisit = new DateTime(2021, 01, 20),
                Complaint = "Too expensive",
                Price = 1000
            };

            var visit3 = new Visit()
            {
                VisitId = 3,
                PatientId = patient2.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 03, 25),
                Price = 1200
            };


            modelBuilder.Entity<Visit>().HasData(visit1, visit2, visit3);


            var diagnosis1 = new Diagnosis()
            {
                DiagnosisId = 1,
                Name = "Diabetes",
                Description = "Needs careful treatment"
            };

            var diagnosis2 = new Diagnosis()
            {
                DiagnosisId = 2,
                Name = "Tachycardia",
                Description = "Nothing serious, just avoid much coffee"
            };

            var diagnosis3 = new Diagnosis()
            {
                DiagnosisId = 3,
                Name = "Headache",
                Description = "Outflow of blood from the head is disturbed"
            };

            modelBuilder.Entity<Diagnosis>().HasData(diagnosis1, diagnosis2, diagnosis3);


            var diagnosisInfo1 = new DiagnosisInfo()
            {
                DiagnosisInfoId = 1,
                DiagnosisId = diagnosis1.DiagnosisId,
                PatientId = patient1.PatientId
            };

            var diagnosisInfo2 = new DiagnosisInfo()
            {
                DiagnosisInfoId = 2,
                PatientId = patient2.PatientId,
                DiagnosisId = diagnosis2.DiagnosisId
            };

            modelBuilder.Entity<DiagnosisInfo>().HasData(diagnosisInfo1, diagnosisInfo2);


            var cabinet1 = new Cabinet()
            {
                CabinetId = 1,
                CabinetNumber = 228
            };

            var cabinet2 = new Cabinet()
            {
                CabinetId = 2,
                CabinetNumber = 320
            };

            var cabinet3 = new Cabinet()
            {
                CabinetId = 3,
                CabinetNumber = 223
            };

            modelBuilder.Entity<Cabinet>().HasData(cabinet1, cabinet2, cabinet3);


            var cabinetInfo1 = new CabinetInfo()
            {
                CabinetInfoId = 1,
                CabinetId = cabinet1.CabinetId,
                DoctorId = doctor1.DoctorId,
                DateStart = new DateTime(2019, 3, 23)/*,
                DateEnd = default*/
            };


            var cabinetInfo2 = new CabinetInfo()
            {
                CabinetInfoId = 2,
                CabinetId = cabinet2.CabinetId,
                DoctorId = doctor2.DoctorId,
                DateStart = new DateTime(2015, 6, 12),
                DateEnd = new DateTime(2018, 3, 21)
            };

            var cabinetInfo3 = new CabinetInfo()
            {
                CabinetInfoId = 3,
                CabinetId = cabinet3.CabinetId,
                DoctorId = doctor2.DoctorId,
                DateStart = new DateTime(2018, 3, 21)/*,
                DateEnd = default*/
            };

            var cabinetInfo4 = new CabinetInfo()
            {
                CabinetInfoId = 4,
                CabinetId = cabinet2.CabinetId,
                DoctorId = doctor3.DoctorId,
                DateStart = new DateTime(2018, 3, 21)
            };

            modelBuilder.Entity<CabinetInfo>().HasData(cabinetInfo1, cabinetInfo2, cabinetInfo3, cabinetInfo4);

        }
    }
}
