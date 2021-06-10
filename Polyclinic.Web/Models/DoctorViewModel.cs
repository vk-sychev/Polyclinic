using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        [DisplayName("Specialty")]
        public int SpecialtyId { get; set; }

        public SpecialtyDTO Specialty { get; set; }

        public string LicenseNumber { get; set; }

        public List<CabinetDTO> Cabinets { get; set; } = new List<CabinetDTO>();

        public List<PatientViewModel> Patients { get; set; } = new List<PatientViewModel>();

        public List<VisitViewModel> Visits { get; set; } = new List<VisitViewModel>();

        public string DoctorFullName { get { return (User != null) ? $"{User.Surname} {User.Name}" : ""; } }
    }
}
