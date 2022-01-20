using AutoMapper;
using Itenso.TimePeriod;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using Polyclinic.Infrastructure.Constants;
using Polyclinic.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> CreateVisitAsync(VisitDTO visitDTO)
        {
            if (visitDTO == null)
            {
                throw new ArgumentNullException(nameof(visitDTO), "Visit is null");
            }

            if (!await IsTimeFree(visitDTO))
            {
                return false;
            }

            var visit = _mapper.Map<Visit>(visitDTO);
            await _visitRepository.CreateVisitAsync(visit);
            await _visitRepository.SaveAsync();

            return true;
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

        public async Task<bool> UpdateVisitAsync(VisitDTO visitDTO)
        {
            if (visitDTO == null)
            {
                throw new ArgumentNullException(nameof(visitDTO), "Visit is null");
            }

            if (!await IsTimeFree(visitDTO))
            {
                return false;
            }

            var visit = _mapper.Map<Visit>(visitDTO);
            _visitRepository.UpdateVisit(visit);
            await _visitRepository.SaveAsync();

            return true;
        }

        private async Task<bool> IsTimeFree(VisitDTO visit)
        {
            var visits = await _visitRepository.GetVisitsByDoctorIdAndDateAsync(visit.DoctorId, visit.DateVisit.Date);
            if (!visits.Any()) 
            {
                return true;
            }

            if (!IsWorkingTime(visit))
            {
                return false;
            }

            if (visits.Any(x => ValidateVisit(x, visit) == false))
            {
                return false;
            }

            return true;
        }

        private bool ValidateVisit(Visit visitFromDb, VisitDTO newVisit)
        {
            var diff = new DateDiff(visitFromDb.DateVisit, newVisit.DateVisit).Minutes;
            if (Math.Abs(diff) > Constants.VisitDurationInMinutes)
            {
                return true;
            }

            return false;
        }

        private bool IsWorkingTime(VisitDTO visit)
        {
            if (visit.DateVisit.TimeOfDay >= Constants.StartWorkTime && visit.DateVisit.TimeOfDay<=Constants.EndWorkTime)
            {
                return true;
            }

            return false;
        }
    }
}
