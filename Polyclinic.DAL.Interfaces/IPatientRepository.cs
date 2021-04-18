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

        Task<IEnumerable<Patient>> GetAllPatiensAsync();

        Task SaveAsync();
    }
}
