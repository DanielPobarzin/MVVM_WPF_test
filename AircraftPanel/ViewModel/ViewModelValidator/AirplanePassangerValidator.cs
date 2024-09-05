using FluentValidation;
using Models.DTOs;
using Models.ModelsValidator;
using System.Text.RegularExpressions;

namespace ViewModel.ViewModelValidator
{
    public class AirplanePassengerValidator : AbstractValidator<AirplanePassenger>
    {
		private readonly PassengerValidator _passengerValidator;
		private readonly FlightValidator _flightValidator;

		public AirplanePassengerValidator()
        {
			_passengerValidator = new PassengerValidator();
			_flightValidator = new FlightValidator();

			RuleFor(passenger => passenger.Passenger)
			.SetValidator(_passengerValidator);

			RuleFor(passenger => passenger.Flight)
				.SetValidator(_flightValidator);
		}
    }
}


