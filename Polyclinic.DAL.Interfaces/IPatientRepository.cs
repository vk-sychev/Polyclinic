using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientByIdAsync(int id);

        Task<List<Patient>> GetPatiensAsync();

        Task<List<Patient>> GetPatientsPaginatedAsync(int pageIndex, int pageSize);

        Task<int> GetCountOfPatientsAsync();

        Task CreatePatientAsync(Patient patient);

        void DeletePatient(Patient patient);

        void UpdatePatient(Patient patient);

        void UpdateUser(User user);

        Task SaveAsync();
    }
}
