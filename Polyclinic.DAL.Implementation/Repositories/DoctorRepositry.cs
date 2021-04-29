using Microsoft.EntityFrameworkCore;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Implementation.EF;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Implementation.Repositories
{
    public class DoctorRepositry : IDoctorRepository
    {
        private readonly PolyclinicContext _db;

        public DoctorRepositry(PolyclinicContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            var doctors = await _db.Doctors.Include(x => x.User).ToListAsync();
            return doctors;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _db.Doctors.FindAsync(id);
            return doctor;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
