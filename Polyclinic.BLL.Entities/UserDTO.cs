using System;
using System.Collections.Generic;
using System.Text;

namespace Polyclinic.BLL.Entities
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BornDate { get; set; }

        public string PassportData { get; set; }

        public string Snills { get; set; }
    }
}
