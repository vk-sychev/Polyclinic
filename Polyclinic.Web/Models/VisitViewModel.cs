using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class VisitViewModel
    {
        public int VisitId { get; set; }

        [DisplayName("Patient")]
        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        [DisplayName("Doctor")]
        public int DoctorId { get; set; }

        public DoctorViewModel Doctor { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateVisit { get; set; }

        public string Complaint { get; set; }

        public double Price { get; set; }
    }
}
