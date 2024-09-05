using FluentValidation;
using Models.DTOs;
using Models.Human;
using System.Text.RegularExpressions;

namespace Models.ModelsValidator
{
    public class PassengerValidator : AbstractValidator<Passenger>
    {
        private const string NamePattern = @"^(?:(?=[а-яА-ЯёЁ\s]+$)[а-яА-ЯёЁ\s]+|(?=[a-zA-Z\s]+$)[a-zA-Z\s]+)$";
        public PassengerValidator()
        {
            RuleFor(person => person.FirstName)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Matches(NamePattern).WithMessage("{PropertyName} must contain only letters of the same alphabet.");

            RuleFor(person => person.LastName)
                .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .Matches(NamePattern).WithMessage("{PropertyName} must contain only letters of the same alphabet.");

            RuleFor(person => person.Patronymic)
                .Matches(NamePattern).WithMessage("{PropertyName} must contain only letters of the same alphabet.");

        }

    }
}

