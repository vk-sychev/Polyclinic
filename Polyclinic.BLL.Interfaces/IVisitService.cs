using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
    public interface IVisitService
    {
        Task CreateVisitAsync(VisitDTO visitDTO);

        Task<List<VisitDTO>> GetVisitsAsync();

        Task<PageModel<VisitDTO>> GetVisitsPaginatedAsync(int pageIndex, int pageSize);

        Task<VisitDTO> GetVisitByIdAsync(int id);

        Task DeleteVisitAsync(int id);

        Task UpdateVisitAsync(VisitDTO visitDTO);
    }
}
