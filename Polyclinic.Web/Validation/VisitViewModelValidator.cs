using FluentValidation;
using Microsoft.Extensions.Logging;
using Polyclinic.Infrastructure.Constants;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Validation
{
    public class VisitViewModelValidator : AbstractValidator<VisitViewModel>
    {
        private readonly static DateTime _now = DateTime.Now;
        private readonly TimeSpan _startWorkTime = Constants.StartWorkTime;
        private readonly TimeSpan _endWorkTime = Constants.EndWorkTime;

        public VisitViewModelValidator()
        {
            RuleFor(x => x.Price).NotEmpty()
                .GreaterThan(1)
                .WithMessage("Price mist be greater than 0!");

            RuleFor(x => x.PatientId)
                .NotEmpty()
                .WithMessage("Patient must be selected!");

            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage("Doctor must be selected!");

            RuleFor(x => x.DateVisit)
                .GreaterThanOrEqualTo(_now)
                .WithMessage($"Time must be greater than {_now}");
                
            RuleFor(x => x.DateVisit.TimeOfDay)
                .InclusiveBetween(_startWorkTime, _endWorkTime)
                .WithMessage($"The working hours are {Constants.StartWorkTime} - {Constants.EndWorkTime}");
        }
    }
}
