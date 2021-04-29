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

        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();

        Task SaveAsync();
    }
}
