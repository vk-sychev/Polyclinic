using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorByIdAsync(int id);

        Task<List<Doctor>> GetDoctorsAsync();

        Task<List<Doctor>> GetDoctorsPaginatedAsync(int pageIndex, int pageSize);

        Task<int> GetCountOfDoctorsAsync();

        Task CreateDoctorAsync(Doctor doctor);

        void DeleteDoctor(Doctor doctor);

        void UpdateDoctor(Doctor doctor);

        Task<List<Specialty>> GetSpecialtiesAsync();

        void UpdateUser(User user);

        Task<List<Doctor>> GetStatistics();

        Task<List<Doctor>> GetStatisticsBySpecialty(int specialtyId);

        Task<List<Doctor>> GetStatisticsByPeriod(DateTime startDate, DateTime endDate);

        Task<List<Doctor>> GetStatisticsBySpecialtyAndPeriod(int specialtyId, DateTime startDate, DateTime endDate);

        Task SaveAsync();
    }
}
