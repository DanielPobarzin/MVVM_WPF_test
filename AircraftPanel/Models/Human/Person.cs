using System.ComponentModel;
using System.Xml.Linq;

namespace Models.Human
{
	public abstract class Person : INotifyPropertyChanged
	{
		private string _firstName;
		private string _lastName;
		private string? _patronymic;

		public string FirstName
		{
			get => _firstName;
			set
			{
				if (value != _firstName)
				{
					_firstName = value;
					OnPropertyChanged(nameof(FirstName));
				}
			}
		}

		public string LastName
		{
			get => _lastName;
			set
			{
				if (value != _lastName)
				{
					_lastName = value;
					OnPropertyChanged(nameof(LastName));
				}
			}
		}

		public string Patronymic
		{
			get
			{
				return _patronymic ?? "";
			} 
			set
			{
				if (value != _patronymic)
				{
					_patronymic = value;
					OnPropertyChanged(nameof(Patronymic));
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
