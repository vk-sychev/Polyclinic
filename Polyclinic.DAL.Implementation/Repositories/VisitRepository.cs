using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Implementation.EF;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Implementation.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly PolyclinicContext _db;

        public VisitRepository(PolyclinicContext context)
        {
            _db = context;
        }

        public async Task CreateVisitAsync(Visit visit)
        {
            var doctor = await _db.Doctors.FindAsync(visit.DoctorId);
            visit.Doctor = doctor;
            var patient = await _db.Patients.FindAsync(visit.PatientId);
            visit.Patient = patient;
            await _db.Visits.AddAsync(visit);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
