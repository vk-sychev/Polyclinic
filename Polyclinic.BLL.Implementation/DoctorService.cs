using AutoMapper;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Interfaces;
using Polyclinic.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository,
                             IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctorsAsync();
            var mappedDoctors = _mapper.Map<List<DoctorDTO>>(doctors);
            return mappedDoctors;
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Doctor's id is null");
            }
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id.Value);
            if (doctor == null)
            {
                throw new NotFoundException($"Doctor with id = {id.Value} isn't found");
            }
            var mappedDoctor = _mapper.Map<DoctorDTO>(doctor);
            return mappedDoctor;
        }
    }
}
