using ViewModel.Interfaces;

namespace ViewModel.Services
{
    public class DateTimeService : IDateTimeService
	{
		public DateTime Now => DateTime.Now;
	}
}
