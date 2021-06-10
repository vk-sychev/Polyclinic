using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
    public interface IPatientService
    {
        Task<PatientDTO> GetPatientByIdAsync(int id);

        Task<List<PatientDTO>> GetPatientsAsync();

        Task<PageModel<PatientDTO>> GetPatientsPaginatedAsync(int pageIndex, int pageSize);

        Task CreatePatientAsync(PatientDTO patientDTO);

        Task DeletePatientAsync(int id);

        Task UpdatePatientAsync(PatientDTO patientDTO);
    }
}
