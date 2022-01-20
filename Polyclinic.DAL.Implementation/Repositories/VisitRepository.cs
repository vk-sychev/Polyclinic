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

        public void DeleteVisit(Visit visit)
        {
            _db.Visits.Remove(visit);
        }

        public Task<Visit> GetVisitByIdAsync(int id)
        {
            return _db.Visits.Where(x => x.VisitId == id)
                                   .Include(d => d.Doctor)
                                   .ThenInclude(u => u.User)
                                   .Include(p => p.Patient)
                                   .ThenInclude(u => u.User)
                                   .FirstOrDefaultAsync();

        }

        public Task<List<Visit>> GetVisitsAsync()
        {
            return _db.Visits.Include(d => d.Doctor)
                                   .ThenInclude(u => u.User)
                                   .Include(p => p.Patient)
                                   .ThenInclude(u => u.User)
                                   .ToListAsync();
        }

        public Task<int> GetCountOfVisitsAsync()
        {
            var query = _db.Visits.Include(d => d.Doctor)
                       .ThenInclude(u => u.User)
                       .Include(p => p.Patient)
                       .ThenInclude(u => u.User);

            return query.CountAsync();
        }

        public Task<List<Visit>> GetVisitsPaginatedAsync(int pageIndex, int pageSize)
        {
            var query = _db.Visits.Include(d => d.Doctor)
                                  .ThenInclude(u => u.User)
                                  .Include(p => p.Patient)
                                  .ThenInclude(u => u.User);

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void UpdateVisit(Visit visit)
        {
            _db.Entry(visit).State = EntityState.Modified;
        }

        public Task<List<Visit>> GetVisitsByDoctorIdAndDateAsync(int doctorId, DateTime date)
        {
            return _db.Visits.Include(d => d.Doctor)
                       .ThenInclude(u => u.User)
                       .Include(p => p.Patient)
                       .ThenInclude(u => u.User)
                       .Where(x => x.DoctorId == doctorId && x.DateVisit.Date == date)
                       .ToListAsync();
        }
    }
}
