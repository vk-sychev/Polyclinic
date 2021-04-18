using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class CabinetInfo
    {
        public int CabinetInfoId { get; set; }

        public int CabinetId { get; set; }

        public Cabinet Cabinet { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
    }
}
