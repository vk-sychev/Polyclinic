using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.BLL.Entities
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public string Policy { get; set; }

        public List<DiagnosisDTO> Diagnosis { get; set; } = new List<DiagnosisDTO>();
    }
}
