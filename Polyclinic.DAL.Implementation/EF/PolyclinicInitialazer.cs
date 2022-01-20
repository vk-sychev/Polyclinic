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

            var user6 = new User()
            {
                UserId = 6,
                Name = "Andrey",
                Surname = "Kartashov",
                BornDate = new DateTime(1989, 03, 10),
                PassportData = "2342343562",
                Snills = "8543"
            };

            var user7 = new User()
            {
                UserId = 7,
                Name = "Kirill",
                Surname = "Mikhaylov",
                BornDate = new DateTime(1995, 01, 16),
                PassportData = "0934765194",
                Snills = "1029"
            };

            var user8 = new User()
            {
                UserId = 8,
                Name = "Alexey",
                Surname = "Tereshkov",
                BornDate = new DateTime(1998, 07, 17),
                PassportData = "1241241897",
                Snills = "9823"
            };

            var user9 = new User()
            {
                UserId = 9,
                Name = "Vitaliy",
                Surname = "Lobanov",
                BornDate = new DateTime(1993, 08, 10),
                PassportData = "0375913498",
                Snills = "9012"
            };

            var user10 = new User()
            {
                UserId = 10,
                Name = "Ruslan",
                Surname = "Mayboroda",
                BornDate = new DateTime(1999, 10, 14),
                PassportData = "4012783409",
                Snills = "1872"
            };

            var user11 = new User()
            {
                UserId = 11,
                Name = "Nikolay",
                Surname = "Kondusov",
                BornDate = new DateTime(1990, 05, 18),
                PassportData = "7812093476",
                Snills = "1047"
            };

            var user12 = new User()
            {
                UserId = 12,
                Name = "Mikhail",
                Surname = "Miclayev",
                BornDate = new DateTime(2000, 09, 01),
                PassportData = "9012456512",
                Snills = "1045"
            };

            modelBuilder.Entity<User>().HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12);



            var specialty1 = new Specialty()
            {
                SpecialtyId = 1,
                Name = "Endocrinologist"
            };

            var specialty2 = new Specialty()
            {
                SpecialtyId = 2,
                Name = "Сardiologist"
            };

            var specialty3 = new Specialty()
            {
                SpecialtyId = 3,
                Name = "Therapist"
            };

            var specialty4 = new Specialty()
            {
                SpecialtyId = 4,
                Name = "Neurologist"
            };

            modelBuilder.Entity<Specialty>().HasData(specialty1, specialty2, specialty3, specialty4);



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
                SpecialtyId = specialty2.SpecialtyId,
                LicenseNumber = "2222"
            };

            var doctor3 = new Doctor()
            {
                DoctorId = 3,
                UserId = user3.UserId,
                SpecialtyId = specialty3.SpecialtyId,
                LicenseNumber = "3333"
            };

            var doctor4 = new Doctor()
            {
                DoctorId = 4,
                UserId = user6.UserId,
                SpecialtyId = specialty4.SpecialtyId,
                LicenseNumber = "4444"
            };

            var doctor5 = new Doctor()
            {
                DoctorId = 5,
                UserId = user7.UserId,
                SpecialtyId = specialty1.SpecialtyId,
                LicenseNumber = "5555"
            };

            var doctor6 = new Doctor()
            {
                DoctorId = 6,
                UserId = user8.UserId,
                SpecialtyId = specialty2.SpecialtyId,
                LicenseNumber = "6666"
            };

            var doctor7 = new Doctor()
            {
                DoctorId = 7,
                UserId = user9.UserId,
                SpecialtyId = specialty3.SpecialtyId,
                LicenseNumber = "7777"
            };

            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2, doctor3, doctor4, doctor5, doctor6, doctor7);


            var patient1 = new Patient()
            {
                PatientId = 1,
                Policy = "123216",
                UserId = user4.UserId
            };

            var patient2 = new Patient()
            {
                PatientId = 2,
                Policy = "213214",
                UserId = user5.UserId
            };

            var patient3 = new Patient()
            {
                PatientId = 3,
                Policy = "091234",
                UserId = user10.UserId
            };

            var patient4 = new Patient()
            {
                PatientId = 4,
                Policy = "561209",
                UserId = user11.UserId
            };

            var patient5 = new Patient()
            {
                PatientId = 5,
                Policy = "048130",
                UserId = user12.UserId
            };


            modelBuilder.Entity<Patient>().HasData(patient1, patient2, patient3, patient4, patient5);


            var visit1 = new Visit()
            {
                VisitId = 1,
                PatientId = patient1.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 06, 20, 10, 00, 00),
                Price = 1300
            };

            var visit2 = new Visit()
            {
                VisitId = 2,
                PatientId = patient1.PatientId,
                DoctorId = doctor2.DoctorId,
                DateVisit = new DateTime(2021, 07, 20, 15, 00, 00),
                Complaint = "Have a headache",
                Price = 1000
            };

            var visit3 = new Visit()
            {
                VisitId = 3,
                PatientId = patient2.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 06, 25, 15, 00, 00),
                Price = 1200
            };

            var visit4 = new Visit()
            {
                VisitId = 4,
                PatientId = patient4.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 06, 25, 15, 30, 00),
                Price = 1200
            };

            var visit5 = new Visit()
            {
                VisitId = 5,
                PatientId = patient5.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 06, 26, 11, 00, 00),
                Price = 1200
            };

            var visit6 = new Visit()
            {
                VisitId = 6,
                PatientId = patient4.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 06, 26, 11, 45, 00),
                Price = 1200
            };

            var visit7 = new Visit()
            {
                VisitId = 7,
                PatientId = patient3.PatientId,
                DoctorId = doctor4.DoctorId,
                DateVisit = new DateTime(2021, 06, 26, 12, 00, 00),
                Price = 1200
            };


            var visit8 = new Visit()
            {
                VisitId = 8,
                PatientId = patient1.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 10, 10, 00, 00),
                Price = 1300
            };

            var visit9 = new Visit()
            {
                VisitId = 9,
                PatientId = patient3.PatientId,
                DoctorId = doctor2.DoctorId,
                DateVisit = new DateTime(2021, 05, 10, 15, 00, 00),
                Complaint = "Have a headache",
                Price = 1000
            };

            var visit10 = new Visit()
            {
                VisitId = 10,
                PatientId = patient2.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 15, 15, 00, 00),
                Price = 1200
            };

            var visit11 = new Visit()
            {
                VisitId = 11,
                PatientId = patient4.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 05, 15, 30, 00),
                Price = 1200
            };

            var visit12 = new Visit()
            {
                VisitId = 12,
                PatientId = patient5.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 05, 16, 11, 00, 00),
                Price = 1200
            };

            var visit13 = new Visit()
            {
                VisitId = 13,
                PatientId = patient4.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 05, 06, 11, 45, 00),
                Price = 1200
            };

            var visit14 = new Visit()
            {
                VisitId = 14,
                PatientId = patient3.PatientId,
                DoctorId = doctor4.DoctorId,
                DateVisit = new DateTime(2021, 05, 30, 12, 00, 00),
                Price = 1200
            };

            var visit15 = new Visit()
            {
                VisitId = 15,
                PatientId = patient1.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 10, 10, 00, 00),
                Price = 1300
            };

            var visit16 = new Visit()
            {
                VisitId = 16,
                PatientId = patient3.PatientId,
                DoctorId = doctor2.DoctorId,
                DateVisit = new DateTime(2021, 05, 10, 15, 00, 00),
                Complaint = "Have a headache",
                Price = 1000
            };

            var visit17 = new Visit()
            {
                VisitId = 17,
                PatientId = patient2.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 15, 15, 00, 00),
                Price = 1200
            };

            var visit18 = new Visit()
            {
                VisitId = 18,
                PatientId = patient4.PatientId,
                DoctorId = doctor1.DoctorId,
                DateVisit = new DateTime(2021, 05, 05, 15, 30, 00),
                Price = 1200
            };

            var visit19 = new Visit()
            {
                VisitId = 19,
                PatientId = patient5.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 05, 16, 11, 00, 00),
                Price = 1200
            };

            var visit20 = new Visit()
            {
                VisitId = 20,
                PatientId = patient4.PatientId,
                DoctorId = doctor5.DoctorId,
                DateVisit = new DateTime(2021, 05, 06, 11, 45, 00),
                Price = 1200
            };

            var visit21 = new Visit()
            {
                VisitId = 21,
                PatientId = patient3.PatientId,
                DoctorId = doctor7.DoctorId,
                DateVisit = new DateTime(2021, 05, 30, 12, 00, 00),
                Price = 1200
            };


            var visit22 = new Visit()
            {
                VisitId = 22,
                PatientId = patient1.PatientId,
                DoctorId = doctor6.DoctorId,
                DateVisit = new DateTime(2021, 07, 25, 11, 00, 00),
                Price = 1200
            };

            var visit23 = new Visit()
            {
                VisitId = 23,
                PatientId = patient4.PatientId,
                DoctorId = doctor7.DoctorId,
                DateVisit = new DateTime(2021, 07, 26, 11, 45, 00),
                Price = 1200
            };

            var visit24 = new Visit()
            {
                VisitId = 24,
                PatientId = patient2.PatientId,
                DoctorId = doctor7.DoctorId,
                DateVisit = new DateTime(2021, 07, 27, 12, 00, 00),
                Price = 1200
            };

            modelBuilder.Entity<Visit>().HasData(visit1, visit2, visit3, visit4, visit5, visit6, visit7, visit8, visit9, visit10,
                                                visit11, visit12, visit13, visit14, visit15, visit16, visit17, visit18, visit19, visit20,
                                                visit21, visit22, visit23, visit24);


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
                DateStart = new DateTime(2019, 3, 23)
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
                DateStart = new DateTime(2018, 3, 21)
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
