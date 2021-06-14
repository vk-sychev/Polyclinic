using FluentValidation;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Validation
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        private readonly string letterPattern = @"^[a-zA-Zа-яА-Я]+\b";
        private readonly string numberPattern = @"\d+";
        private readonly DateTime todaysDate = DateTime.Today;

        public UserViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches(letterPattern)
                .WithMessage("Name must contain only letters");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .Matches(letterPattern)
                .WithMessage("Name must contain only letters");

            RuleFor(x => x.BornDate).LessThan(todaysDate)
                        .WithMessage($"Date of Birth must be less than today's date: { todaysDate }")
                        .Must(x => x.Year > todaysDate.Year - 100)
                        .WithMessage($"Year of Birth must be greater than {todaysDate.Year - 100}");

            RuleFor(x => x.PassportData).NotEmpty()
                .Matches(numberPattern)
                .WithMessage("PassportData must contain only numbers");

            RuleFor(x => x.Snills).NotEmpty()
                .Matches(numberPattern)
                .WithMessage("Snills must contain only numbers");

        }
    }
}
