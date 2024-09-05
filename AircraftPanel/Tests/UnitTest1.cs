using Models.DTOs;
using Models.Human;
using Models.Travelling;
using Shouldly;
using System.Text.Json;
using ViewModel.Services;
using ViewModel.ViewModelValidator;

namespace Tests
{
	public class UnitTest1
	{
		private readonly AirplanePassengerValidator _validator;
		private readonly JsonFileService _jsonFileService;

		public UnitTest1()
		{
			_validator = new AirplanePassengerValidator();
			_jsonFileService = new JsonFileService();

		}

		[Theory]
		[InlineData("Иван", "Иванов", "Иванович", "AB123", "12:00:00")]
		[InlineData("Анна", "Петрова", "Сергеевна", "AB123", "12:00:00")]
		[InlineData("Дмитрий", "Сидоров", "Александрович", "AB123", "12:00:00")]
		public void Test1(string firstName, string lastName, string patronymic, string routeNumber, string time)
		{
			// Arrange
			var passenger = new AirplanePassenger
			{
				Passenger = new Passenger { FirstName = firstName, LastName = lastName, Patronymic = patronymic },
				Flight = new Flight { RouteNumber = routeNumber, DepartureTime = TimeSpan.Parse(time) }
			};

			// Act
			var result = _validator.Validate(passenger);

			// Assert
			result.IsValid.ShouldBeTrue();
		}

		[Theory]
		[InlineData("Иdf3", "Иваов", "Иванович", "AB123", "12:00:00", "First Name must contain only letters of the same alphabet.")]
		[InlineData("Анна", "Пе332ова", "Серfевна", "AB123", "12:00:00", "Last Name must contain only letters of the same alphabet.")]
		[InlineData("Дмитрий", "Сидоров", "Алекс2варович", "AB123", "12:00:00", "Patronymic must contain only letters of the same alphabet.")]
		[InlineData("Дмитрий", "Сидоров", "Александрович", "", "12:00:00", "Route Number cannot be empty.")]
		[InlineData("Дмитрий", "Сидоров", "Александрович", "AB123", "2.12:00:00", "Departure Time must be in the format hh:mm:ss.")]
		public void Test2(string firstName, string lastName, string patronymic, string routeNumber, string time, string expectedErrorMessage)
		{
			// Arrange
			var passenger = new AirplanePassenger
			{
				Passenger = new Passenger { FirstName = firstName, LastName = lastName, Patronymic = patronymic },
				Flight = new Flight { RouteNumber = routeNumber, DepartureTime = TimeSpan.Parse(time) }
			};

			// Act
			var result = _validator.Validate(passenger);

			// Assert
			result.IsValid.ShouldBeFalse();
			result.Errors.ShouldNotBeEmpty();
			result.Errors.ShouldContain(e => e.ErrorMessage == expectedErrorMessage);
		}

		[Fact]
		public void Test3()
		{
			// Arrange
			var testPassengers = new List<AirplanePassenger>
			{
				new AirplanePassenger 
				{ 
					Passenger = new Passenger
					{
						FirstName = "Antonio",
						LastName = "Banderas",
						Patronymic = ""
					},
					Flight = new Flight 
					{ 
						RouteNumber = "FL103",
						DepartureTime = new TimeSpan(10, 0, 0)
					}
				},
				new AirplanePassenger
				{
					Passenger = new Passenger
					{
						FirstName = "Nikolas",
						LastName = "Cage",
						Patronymic = ""
					},
					Flight = new Flight
					{
						RouteNumber = "FL113",
						DepartureTime = new TimeSpan(12, 0, 0)
					}
				},
			};

			string json = JsonSerializer.Serialize(testPassengers);
			string fileName = "test.json";

			File.WriteAllText(fileName, json);

			// Act
			var result = _jsonFileService.Open(fileName);

			// Assert
			result.Count.ShouldBe(2);

			result[0].Flight.DepartureTime.ShouldBe(new TimeSpan(10, 0, 0));
			result[0].Flight.RouteNumber.ShouldBe("FL103");
			result[0].Passenger.FirstName.ShouldBe("Antonio");
			result[0].Passenger.LastName.ShouldBe("Banderas");
			result[0].Passenger.Patronymic.ShouldBe("");

			result[1].Flight.DepartureTime.ShouldBe(new TimeSpan(12, 0, 0));
			result[1].Flight.RouteNumber.ShouldBe("FL113");
			result[1].Passenger.FirstName.ShouldBe("Nikolas");
			result[1].Passenger.LastName.ShouldBe("Cage");
			result[1].Passenger.Patronymic.ShouldBe("");

			// Clean up
			File.Delete(fileName);
		}

		[Fact]
		public void Test4()
		{
			// Arrange
			string nonExistentFileName = "nonexistent.json";

			// Act & Assert
			var exception = Should.Throw<Exception>(() => _jsonFileService.Open(nonExistentFileName));
			exception.Message.ShouldBe("File opening error.");
		}
	}
}