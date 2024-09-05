using Models.Human;
using Models.Travelling;

namespace Models.DTOs
{
	public class AirplanePassenger
	{
		public Passenger Passenger { get; set; }
		public Flight Flight { get; set; }
	}
}
