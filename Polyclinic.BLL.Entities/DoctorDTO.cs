using System;
using System.Collections.Generic;

namespace Polyclinic.BLL.Entities
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public int SpecialtyId { get; set; }

        public SpecialtyDTO Specialty { get; set; }

        public string LicenseNumber { get; set; }

        public List<CabinetDTO> Cabinets { get; set; } = new List<CabinetDTO>();

        public List<PatientDTO> Patients { get; set; } = new List<PatientDTO>();

        public List<VisitDTO> Visits { get; set; } = new List<VisitDTO>();
    }
}
