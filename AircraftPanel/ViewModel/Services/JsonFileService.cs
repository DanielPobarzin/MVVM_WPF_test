using Models.DTOs;
using Serilog;
using System.IO;
using System.Text.Json;
using ViewModel.Interfaces;

namespace ViewModel.Services
{
    public class JsonFileService : IFileService<AirplanePassenger>
	{
		public List<AirplanePassenger> Open(string fileName)
		{
			try
			{
				using (FileStream fs = new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					var result = JsonSerializer.Deserialize<List<AirplanePassenger>>(fs);
					
					if (result is List<AirplanePassenger> passengers)
					{
						passengers.Sort((f1, f2) => f1.Flight.DepartureTime.CompareTo(f2.Flight.DepartureTime));
						Log.Information("The file has been identified and opened successfully.");
						return passengers;
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error($"The data from the file has not been received. Error: {ex.Message}");
				throw new Exception("File opening error.");
			}
			return new List<AirplanePassenger>();
		}
	}
}
