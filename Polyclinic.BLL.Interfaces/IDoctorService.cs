using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorDTO> GetDoctorByIdAsync(int id);

        Task<List<DoctorDTO>> GetDoctorsAsync();

        Task<PageModel<DoctorDTO>> GetDoctorsPaginatedAsync(int pageIndex, int pageSize);

        Task CreateDoctorAsync(DoctorDTO doctorDTO);

        Task DeleteDoctorAsync(int id);

        Task UpdateDoctorAsync(DoctorDTO doctorDTO);

        Task<List<SpecialtyDTO>> GetSpecialtiesAsync();

        Task<List<DoctorDTO>> GetStatisticsAsync(SearchModel model);

        Task<byte[]> GetStatisticsInFileAsync(SearchModel model);
    }
}
