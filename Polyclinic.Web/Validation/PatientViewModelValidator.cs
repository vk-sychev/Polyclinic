using FluentValidation;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Validation
{
    public class PatientViewModelValidator : AbstractValidator<PatientViewModel>
    {
        private readonly string numberPattern = @"\d+";

        public PatientViewModelValidator()
        {
            RuleFor(x => x.Policy).NotEmpty()
                .Matches(numberPattern)
                .WithMessage("Policy must contain only numbers");
        }
    }
}
