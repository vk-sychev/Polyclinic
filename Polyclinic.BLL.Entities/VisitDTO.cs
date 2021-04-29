using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.BLL.Entities
{
    public class VisitDTO
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public PatientDTO Patient { get; set; }

        public int DoctorId { get; set; }

        public DoctorDTO Doctor { get; set; }

        public DateTime DateVisit { get; set; }

        public string Complaint { get; set; }

        public double Price { get; set; }
    }
}
