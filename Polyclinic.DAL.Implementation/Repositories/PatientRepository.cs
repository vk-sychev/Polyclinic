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

        public async Task<IEnumerable<Patient>> GetAllPatiensAsync()
        {
            var patiens = await _db.Patients.Include(x => x.User).ToListAsync();
            return patiens;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            return patient;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
