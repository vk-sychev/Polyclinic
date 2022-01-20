using Polyclinic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        public string Policy { get; set; }

        public List<DiagnosisDTO> Diagnosis { get; set; } = new List<DiagnosisDTO>();

        [DisplayName("Patient's FullName")]
        public string PatientFullName { get { return (User != null) ? $"{User.Surname} {User.Name}" : ""; } }
    }
}
