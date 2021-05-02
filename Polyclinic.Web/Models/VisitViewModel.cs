using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class VisitViewModel
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        public int DoctorId { get; set; }

        public DoctorViewModel Doctor { get; set; }

        public DateTime DateVisit { get; set; }

        public string Complaint { get; set; }

        public double Price { get; set; }
    }
}
