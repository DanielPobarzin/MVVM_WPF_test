using FluentValidation;
using Models.DTOs;
using Models.Travelling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.ModelsValidator
{
    public class FlightValidator : AbstractValidator<Flight>
    {
        public FlightValidator()
        {
            RuleFor(person => person.RouteNumber)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.");

            RuleFor(person => person.DepartureTime)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .Must(BeValidDepartureTime).WithMessage("{PropertyName} must be in the format hh:mm:ss.");
        }
        private bool BeValidDepartureTime(TimeSpan departureTime)
        {
            if (departureTime.Days != 0)
            {
                return false;
            }
            return Regex.IsMatch(departureTime.ToString(@"hh\:mm\:ss"), @"^([01]\d|2[0-3]):([0-5]\d):([0-5]\d)$");
        }
    }
}
