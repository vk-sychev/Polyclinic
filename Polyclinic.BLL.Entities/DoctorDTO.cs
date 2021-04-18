using System;

namespace Polyclinic.BLL.Entities
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
