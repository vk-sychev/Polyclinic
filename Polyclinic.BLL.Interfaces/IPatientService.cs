using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDTO> GetPatientByIdAsync(int? id);

        Task<List<PatientDTO>> GetAllPatientsAsync();
    }
}
