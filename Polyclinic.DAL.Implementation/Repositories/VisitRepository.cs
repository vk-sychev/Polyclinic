using Microsoft.EntityFrameworkCore;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Implementation.EF;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteVisitAsync(Visit visit)
        {
            _db.Visits.Remove(visit);
        }

        public async Task<Visit> GetVisitByIdAsync(int id)
        {
            return await _db.Visits.Where(x => x.VisitId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Visit>> GetVisitsAsync()
        {
            return await _db.Visits.Include(d => d.Doctor)
                                   .ThenInclude(u => u.User)
                                   .Include(s => s.Patient)
                                   .ThenInclude(u => u.User)
                                   .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void UpdateVisitAsync(Visit visit)
        {
            _db.Entry(visit).State = EntityState.Modified;
        }
    }
}
