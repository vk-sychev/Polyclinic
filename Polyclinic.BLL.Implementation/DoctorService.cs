using AutoMapper;
using ClosedXML.Excel;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using Polyclinic.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<List<DoctorDTO>> GetStatisticsAsync(SearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var doctors = await GetStatistics(model);

            var mappedDoctors = _mapper.Map<List<DoctorDTO>>(doctors);
            return mappedDoctors;
        }

        public async Task<byte[]> GetStatisticsInFileAsync(SearchModel model)
        {
            //model.StartDate = new DateTime(model.StartDate.Year, model.StartDate.Da)

            var doctors = await GetStatisticsAsync(model);
            byte[] content;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Statistics");
                worksheet.ColumnWidth = 15;
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "DoctorId";
                worksheet.Cell(currentRow, 2).Value = "FullName";
                worksheet.Cell(currentRow, 3).Value = "BornDate";
                worksheet.Cell(currentRow, 4).Value = "SpecialtyName";
                worksheet.Cell(currentRow, 5).Value = "LicenseNumber";
                worksheet.Cell(currentRow, 6).Value = "Number of Visits";
                worksheet.Cell(currentRow, 7).Value = "Number of Patiens";
                worksheet.Cell(currentRow, 8).Value = "Earned Money";

                if (model.IsPeriod)
                {
                    worksheet.Cell(currentRow, 9).Value = "Start Period";
                    worksheet.Cell(currentRow, 10).Value = "End Period";
                }

                currentRow++;

                foreach (var doctor in doctors)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = doctor.DoctorId;
                    worksheet.Cell(currentRow, 2).Value = $"{doctor.User.Surname} {doctor.User.Name}";
                    worksheet.Cell(currentRow, 3).Value = doctor.User.BornDate;
                    worksheet.Cell(currentRow, 4).Value = doctor.Specialty.Name;
                    worksheet.Cell(currentRow, 5).Value = doctor.LicenseNumber;
                    worksheet.Cell(currentRow, 6).Value = doctor.Visits.Count;
                    worksheet.Cell(currentRow, 7).Value = doctor.Patients.Count;
                    worksheet.Cell(currentRow, 8).Value = doctor.Visits.Sum(x => x.Price);

                    if (model.IsPeriod)
                    {
                        worksheet.Cell(currentRow, 9).Value = model.StartDate.ToShortDateString();
                        worksheet.Cell(currentRow, 10).Value = model.EndDate.ToShortDateString();
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    content = stream.ToArray();
                }
            }

            return content;
        }

        private Task<List<Doctor>> GetStatistics(SearchModel model)
        {
            if (model.IsPeriod == true)
            {
                if (model.SpecialtyId == 0)
                {
                    return _doctorRepository.GetStatisticsByPeriod(model.StartDate, model.EndDate);
                }
                else
                {
                    return _doctorRepository.GetStatisticsBySpecialtyAndPeriod(model.SpecialtyId, model.StartDate, model.EndDate);
                }
            }
            else
            {
                if (model.SpecialtyId == 0)
                {
                    return _doctorRepository.GetStatistics();
                }
                else
                {
                    return _doctorRepository.GetStatisticsBySpecialty(model.SpecialtyId);
                }
            }
        }
    }
}
