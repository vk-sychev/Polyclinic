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
    public class DoctorRepositry : IDoctorRepository
    {
        private readonly PolyclinicContext _db;

        public DoctorRepositry(PolyclinicContext context)
        {
            _db = context;
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _db.Doctors.AddAsync(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            _db.Doctors.Remove(doctor);
        }

        public Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return _db.Doctors.Include(x => x.User)
                .Include(x => x.CabinetInfos)
                .ThenInclude(x => x.Cabinet)
                .Include(x => x.Specialty)
                .FirstOrDefaultAsync(x => x.DoctorId == id);
        }

        public Task<List<Doctor>> GetDoctorsAsync()
        {
            return _db.Doctors.Include(x => x.User)
                    .Include(x => x.CabinetInfos)
                    .ThenInclude(x => x.Cabinet)
                    .Include(x => x.Specialty)
                    .ToListAsync();
        }

        public Task<int> GetCountOfDoctorsAsync()
        {
            var query = _db.Doctors.Include(x => x.User)
                    .Include(x => x.CabinetInfos)
                    .ThenInclude(x => x.Cabinet)
                    .Include(x => x.Specialty);

            return query.CountAsync();
        }

        public Task<List<Doctor>> GetDoctorsPaginatedAsync(int pageIndex, int pageSize)
        {
            var query = _db.Doctors.Include(x => x.User)
                    .Include(x => x.CabinetInfos)
                    .ThenInclude(x => x.Cabinet)
                    .Include(x => x.Specialty);

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _db.Entry(doctor).State = EntityState.Modified;
        }

        public void UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }


        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public Task<List<Specialty>> GetSpecialtiesAsync()
        {
            return _db.Specialties.ToListAsync();
        }

        public void UpdatePatient(Patient patient)
        {
            _db.Entry(patient).State = EntityState.Modified;
        }

        public Task<List<Doctor>> GetStatistics()
        {
            return _db.Doctors.Include(x => x.User)
                              .Include(x => x.Visits)
                              .ThenInclude(x => x.Patient)
                              .Include(x => x.Specialty)
                              .ToListAsync();
        }

        public Task<List<Doctor>> GetStatisticsBySpecialty(int specialtyId)
        {
            return _db.Doctors.Include(x => x.User)
                              .Include(x => x.Visits)
                              .ThenInclude(x => x.Patient)
                              .Include(x => x.Specialty)
                              .Where(x => x.SpecialtyId == specialtyId)
                              .ToListAsync();
        }

        public Task<List<Doctor>> GetStatisticsByPeriod(DateTime startDate, DateTime endDate)
        {
            return _db.Doctors.Include(x => x.User)
                              .Include(x => x.Visits
                                    .Where(x => x.DateVisit >= startDate && x.DateVisit <= endDate))
                              .ThenInclude(x => x.Patient)
                              .Include(x => x.Specialty)
                              .ToListAsync();
        }

        public Task<List<Doctor>> GetStatisticsBySpecialtyAndPeriod(int specialtyId, DateTime startDate, DateTime endDate)
        {
            return _db.Doctors.Include(x => x.User)
                  .Include(x => x.Visits
                        .Where(x => x.DateVisit >= startDate && x.DateVisit <= endDate))
                  .ThenInclude(x => x.Patient)
                  .Include(x => x.Specialty)
                  .Where(x => x.SpecialtyId == specialtyId)
                  .ToListAsync();
        }
    }
}
