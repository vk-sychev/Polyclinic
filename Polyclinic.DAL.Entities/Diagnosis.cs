using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class Diagnosis
    {
        public int DiagnosisId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<DiagnosisInfo> DiagnosisInfos { get; set; }
    }
}
