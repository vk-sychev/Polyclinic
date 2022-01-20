using FluentValidation;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Validation
{
    public class DoctorViewModelValidator : AbstractValidator<DoctorViewModel>
    {
        private readonly string numberPattern = @"\d+";

        public DoctorViewModelValidator()
        {
            RuleFor(x => x.SpecialtyId)
                .NotEmpty()
                .WithMessage("Specialty must be selected!");

            RuleFor(x => x.LicenseNumber).NotEmpty()
                .Matches(numberPattern)
                .WithMessage("LicenseNumber must contain only numbers");
        }
    }
}
