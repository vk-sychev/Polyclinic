using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class DiagnosisInfo
    {
        public int DiagnosisInfoId { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int DiagnosisId { get; set; }

        public Diagnosis Diagnosis { get; set; }
    }
}
