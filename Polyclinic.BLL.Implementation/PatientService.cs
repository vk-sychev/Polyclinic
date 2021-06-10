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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository,
                              IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDTO>> GetPatientsAsync()
        {
            var patients = await _patientRepository.GetPatiensAsync();
            var mappedPatiens = _mapper.Map<List<PatientDTO>>(patients);
            return mappedPatiens;
        }

        public async  Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Patient's id <= 0");
            }
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException($"Patient with id = {id} isn't found");
            }
            var mappedPatient = _mapper.Map<PatientDTO>(patient);
            return mappedPatient;
        }

        public async Task<PageModel<PatientDTO>> GetPatientsPaginatedAsync(int pageIndex, int pageSize)
        {
            var patients = await _patientRepository.GetPatientsPaginatedAsync(pageIndex, pageSize);
            var mappedPatiens = _mapper.Map<List<PatientDTO>>(patients);

            var count = await _patientRepository.GetCountOfPatientsAsync();
            return new PageModel<PatientDTO>() { Items = mappedPatiens, Count = count };
        }

        public async Task CreatePatientAsync(PatientDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                throw new ArgumentNullException(nameof(doctorDTO));
            }

            var doctor = _mapper.Map<Patient>(doctorDTO);

            await _patientRepository.CreatePatientAsync(doctor);
            await _patientRepository.SaveAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Patient's id <= 0");
            }

            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException($"Patient with id = {id} isn't found");
            }

            _patientRepository.DeletePatient(patient);
            await _patientRepository.SaveAsync();
        }

        public async Task UpdatePatientAsync(PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                throw new ArgumentNullException(nameof(patientDTO));
            }

            var patient = _mapper.Map<Patient>(patientDTO);

            _patientRepository.UpdatePatient(patient);
            patient.User.UserId = patient.UserId;
            _patientRepository.UpdateUser(patient.User);
            await _patientRepository.SaveAsync();
        }
    }
}
