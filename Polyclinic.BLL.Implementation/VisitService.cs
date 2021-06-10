using AutoMapper;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using Polyclinic.Infrastructure.Exceptions;
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

        public async Task CreateVisitAsync(VisitDTO visitDTO)
        {
            if (visitDTO == null)
            {
                throw new ArgumentNullException(nameof(visitDTO), "Visit is null");
            }

            var visit = _mapper.Map<Visit>(visitDTO);
            await _visitRepository.CreateVisitAsync(visit);
            await _visitRepository.SaveAsync();
        }

        public async Task DeleteVisitAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Visit's id <= 0");
            }

            var visit = await _visitRepository.GetVisitByIdAsync(id);

            if (visit == null)
            {
                throw new NotFoundException($"Visit with id = {id} isn't found");
            }
            _visitRepository.DeleteVisit(visit);
            await _visitRepository.SaveAsync();
        }

        public async Task<VisitDTO> GetVisitByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Visit's id <= 0");
            }

            var visit = await _visitRepository.GetVisitByIdAsync(id);

            if (visit == null)
            {
                throw new NotFoundException($"Visit with id = {id} isn't found");
            }

            var mappedVisit = _mapper.Map<VisitDTO>(visit);
            return mappedVisit;
        }

        public async Task<List<VisitDTO>> GetVisitsAsync()
        {
            var visits = await _visitRepository.GetVisitsAsync();
            var mappedVisits = _mapper.Map<List<VisitDTO>>(visits);
            return mappedVisits;
        }

        public async Task<PageModel<VisitDTO>> GetVisitsPaginatedAsync(int pageIndex, int pageSize)
        {
            var visits = await _visitRepository.GetVisitsPaginatedAsync(pageIndex, pageSize);
            var mappedVisits = _mapper.Map<List<VisitDTO>>(visits);

            var count = await _visitRepository.GetCountOfVisitsAsync();
            return new PageModel<VisitDTO>() { Items = mappedVisits, Count = count };
        }

        public Task UpdateVisitAsync(VisitDTO visitDTO)
        {
            if (visitDTO == null)
            {
                throw new ArgumentNullException(nameof(visitDTO), "Visit is null");
            }
            var visit = _mapper.Map<Visit>(visitDTO);
            _visitRepository.UpdateVisit(visit);
            return _visitRepository.SaveAsync();
        }
    }
}
