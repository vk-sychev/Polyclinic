using AutoMapper;
using Polyclinic.BLL.Entities;
using Polyclinic.DAL.Entities;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Doctor, DoctorDTO>(MemberList.Destination).ReverseMap();
            CreateMap<Visit, VisitDTO>(MemberList.Destination).ReverseMap();
            CreateMap<User, UserDTO>(MemberList.Destination).ReverseMap();

            CreateMap<DoctorViewModel, DoctorDTO>().ReverseMap();
            CreateMap<VisitViewModel, VisitDTO>().ReverseMap();
            CreateMap<PatientViewModel, PatientDTO>().ReverseMap();
            CreateMap<UserViewModel, UserDTO>().ReverseMap();

            CreateMap<Specialty, SpecialtyDTO>().ReverseMap();
            CreateMap<Cabinet, CabinetDTO>().ReverseMap();
        }
    }
}
