using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }

        public string DoctorFullName { get { return (User != null) ? $"{User.Surname} {User.Name}" : ""; } }
    }
}
