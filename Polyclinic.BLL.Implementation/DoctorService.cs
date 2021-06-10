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

        public async Task<List<DoctorDTO>> GetDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetDoctorsAsync();
            var mappedDoctors = _mapper.Map<List<DoctorDTO>>(doctors);
            return mappedDoctors;
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Doctor's id <= 0");
            }

            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                throw new NotFoundException($"Doctor with id = {id} isn't found");
            }

            var mappedDoctor = _mapper.Map<DoctorDTO>(doctor);
            return mappedDoctor;
        }

        public async Task<PageModel<DoctorDTO>> GetDoctorsPaginatedAsync(int pageIndex, int pageSize)
        {
            var doctors = await _doctorRepository.GetDoctorsPaginatedAsync(pageIndex, pageSize);
            var mappedDoctors = _mapper.Map<List<DoctorDTO>>(doctors);

            var count = await _doctorRepository.GetCountOfDoctorsAsync();
            return new PageModel<DoctorDTO>() { Items = mappedDoctors, Count = count };
        }

        public async Task CreateDoctorAsync(DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                throw new ArgumentNullException(nameof(doctorDTO));
            }

            var doctor = _mapper.Map<Doctor>(doctorDTO);

            await _doctorRepository.CreateDoctorAsync(doctor);
            await _doctorRepository.SaveAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Doctor's id <= 0");
            }

            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                throw new NotFoundException($"Doctor with id = {id} isn't found");
            }

            _doctorRepository.DeleteDoctor(doctor);
            await _doctorRepository.SaveAsync();
        }

        public async Task UpdateDoctorAsync(DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                throw new ArgumentNullException(nameof(doctorDTO));
            }

            var doctor = _mapper.Map<Doctor>(doctorDTO);
            _doctorRepository.UpdateDoctor(doctor);
            doctor.User.UserId = doctor.UserId;
            _doctorRepository.UpdateUser(doctor.User);
            await _doctorRepository.SaveAsync();
        }

        public async Task<List<SpecialtyDTO>> GetSpecialtiesAsync()
        {
            var specialties = await _doctorRepository.GetSpecialtiesAsync();
            var mappedSpecialties = _mapper.Map<List<SpecialtyDTO>>(specialties);
            return mappedSpecialties;
        }

        public async Task<List<DoctorDTO>> GetStatistics()
        {
            var doctors = await _doctorRepository.GetStatistics();
            var mappedDoctors = _mapper.Map<List<DoctorDTO>>(doctors);
            return mappedDoctors;
        }
    }
}
