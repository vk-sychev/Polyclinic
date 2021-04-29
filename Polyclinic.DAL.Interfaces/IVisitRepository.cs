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
    }
}
