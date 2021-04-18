using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class Visit
    {
        public int VisitId { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime DateVisit { get; set; }

        public string Complaint { get; set; }

        public double Price { get; set; }
    }
}
