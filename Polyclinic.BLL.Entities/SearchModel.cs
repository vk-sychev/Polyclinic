using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.BLL.Entities
{
    public class SearchModel
    {
        public bool IsPeriod { get; set; }

        public int SpecialtyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
