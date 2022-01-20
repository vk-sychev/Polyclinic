using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        public string PassportData { get; set; }

        public string Snills { get; set; }
    }
}
