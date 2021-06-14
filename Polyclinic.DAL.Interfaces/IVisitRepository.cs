using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Interfaces
{
    public interface IVisitRepository
    {
        Task CreateVisitAsync(Visit visit);

        Task SaveAsync();

        Task<List<Visit>> GetVisitsAsync();

        Task<List<Visit>> GetVisitsByDoctorIdAndDateAsync(int doctorId, DateTime date);

        Task<List<Visit>> GetVisitsPaginatedAsync(int pageIndex, int pageSize);

        Task<int> GetCountOfVisitsAsync();

        Task<Visit> GetVisitByIdAsync(int id);

        void DeleteVisit(Visit visit);

        void UpdateVisit(Visit visit);
    }
}
