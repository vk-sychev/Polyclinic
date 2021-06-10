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
    public class PatientRepository : IPatientRepository
    {
        private readonly PolyclinicContext _db;

        public PatientRepository(PolyclinicContext context)
        {
            _db = context;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
        }

        public void DeletePatient(Patient patient)
        {
            _db.Patients.Remove(patient);
        }


        public Task<List<Patient>> GetPatiensAsync()
        {
            return _db.Patients.Include(x => x.User)
                .Include(x => x.DiagnosisInfos)
                .ThenInclude(x => x.Diagnosis)
                .ToListAsync();
        }

        public Task<Patient> GetPatientByIdAsync(int id)
        {
            return _db.Patients.Include(x => x.User)
                        .Include(x => x.DiagnosisInfos)
                        .ThenInclude(x => x.Diagnosis).FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public Task<int> GetCountOfPatientsAsync()
        {
            var query = _db.Patients.Include(x => x.User)
                .Include(x => x.DiagnosisInfos)
                .ThenInclude(x => x.Diagnosis);

            return query.CountAsync();
        }

        public Task<List<Patient>> GetPatientsPaginatedAsync(int pageIndex, int pageSize)
        {
            var query = _db.Patients.Include(x => x.User)
                .Include(x => x.DiagnosisInfos)
                .ThenInclude(x => x.Diagnosis);

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public void UpdatePatient(Patient patient)
        {
            _db.Entry(patient).State = EntityState.Modified;
        }

        public void UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
