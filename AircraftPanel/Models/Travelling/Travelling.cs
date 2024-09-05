using System.ComponentModel;

namespace Models.Travelling
{
	public abstract class Travelling : INotifyPropertyChanged
	{
		private TimeSpan _departureTime;
		private string _routeNumber;

		public TimeSpan DepartureTime
		{
			get => _departureTime;
			set
			{
				if (value != _departureTime)
				{
					_departureTime = value;
					OnPropertyChanged(nameof(DepartureTime));
				}
			}
		}

		public string RouteNumber
		{
			get => _routeNumber;
			set
			{
				if (value != _routeNumber)
				{
					_routeNumber = value;
					OnPropertyChanged(nameof(RouteNumber));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
