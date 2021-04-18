using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Policy { get; set; }

        public List<DiagnosisInfo> DiagnosisInfos { get; set; }

        public List<Visit> Visits { get; set; }
    }
}
