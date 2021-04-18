using AutoMapper;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Implementation
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;

        public VisitService(IVisitRepository visitRepository,
                            IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public async Task CreateVisit(VisitDTO visitDTO)
        {
            if (visitDTO == null)
            {
                throw new ArgumentNullException(nameof(visitDTO), "Visit is null");
            }
            var visit = _mapper.Map<Visit>(visitDTO);
            await _visitRepository.CreateVisitAsync(visit);
            await _visitRepository.SaveAsync();
        }
    }
}
