using Models.DTOs;
using Serilog;
using System.IO;
using System.Text.Json;

namespace ViewModel.Helpers
{
	public static class TestGenerate
    {
        public static void Generate()
        {
            var flights = GenerateFlights(10000);
            string json = JsonSerializer.Serialize(flights, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("Passengers.json", json);
        }

        public static List<AirplanePassenger> GenerateFlights(int count)
        {
            var random = new Random();
            var firstName = new List<string>
            {
                "Ilya",
                "Constaнтин",
                "Ivan",
                "Oleg",
                "Sasha",
                "Nokolai",
                "Igor",
                "Vova",
                "Dima",
                "Anton",
                "Lesha"
            };

            var lastName = new List<string>
            {
                "Самsonov",
                "Sidorov",
                "Smirnov",
                "Sidorov",
                "Popov",
                "Ivanov",
                "Kruglov",
                "Saharov",
                "Antonov",
                "Chertkov"
            };
            var patronymic = new List<string>
            {
                "Георgievich",
                "Petrovich",
                "Aleksandrovich",
                "Sememnovich",
                "Dmitrievich",
                "Antonovich",
                "Nikolaevich",
                "Igorevich",
                "Alecseevich",
                "Bedrosovich",
                "Artemovich"
            };

            var flights = new List<AirplanePassenger>();
            for (int i = 0; i < count; i++)
            {
                int hours = random.Next(0, 24);
                int minutes = random.Next(0, 60);
                int seconds = random.Next(0, 60);

                var flight = new AirplanePassenger
                {
                    Flight = new Models.Travelling.Flight
                    {
                        RouteNumber = $"FL{random.Next(500, 1000)}",
                        DepartureTime = new TimeSpan(hours, minutes, seconds),

                    },
                    Passenger = new Models.Human.Passenger
                    {
                        FirstName = firstName[random.Next(firstName.Count)],
                        LastName = lastName[random.Next(lastName.Count)],
                        Patronymic = patronymic[random.Next(patronymic.Count)]
                    }
                };
                flights.Add(flight);
            }
            Log.Information("Successful generation of the test file.");
            return flights;
        }
    }
}
