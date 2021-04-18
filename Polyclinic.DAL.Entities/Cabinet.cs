using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.DAL.Entities
{
    public class Cabinet
    {
        public int CabinetId { get; set; }

        public int CabinetNumber { get; set; }

        public string Description { get; set; }

        public List<CabinetInfo> CabinetInfos { get; set; }
    }
}
