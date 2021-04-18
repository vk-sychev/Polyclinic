using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public string LicenseNumber { get; set; }

        public List<CabinetInfo> CabinetInfos { get; set; }

        public List<Visit> Visits { get; set; }
    }
}
