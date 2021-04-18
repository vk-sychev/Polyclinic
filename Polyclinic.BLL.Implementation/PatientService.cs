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

        public async Task<List<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatiensAsync();
            var mappedPatiens = _mapper.Map<List<PatientDTO>>(patients);
            return mappedPatiens;
        }

        public async  Task<PatientDTO> GetPatientByIdAsync(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Student's id is null");
            }
            var patient = await _patientRepository.GetPatientByIdAsync(id.Value);
            if (patient == null)
            {
                throw new NotFoundException($"Patient with id = {id.Value} isn't found");
            }
            var mappedPatient = _mapper.Map<PatientDTO>(patient);
            return mappedPatient;
        }
    }
}
