using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Interfaces
{
    public interface IVisitService
    {
        Task CreateVisit(VisitDTO visit);
    }
}
