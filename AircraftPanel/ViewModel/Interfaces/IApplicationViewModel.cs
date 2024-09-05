using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel.Interfaces
{
	public interface IApplicationViewModel : INotifyPropertyChanged
	{
		RelayCommand CloseCommand { get; }
		RelayCommand MaxCommand { get; }
		RelayCommand MoveWindowCommand { get; }
		RelayCommand LoadPassengersCommand { get; }

		ObservableCollection<AirplanePassenger> Passengers { get; }
		int CurrentPage { get; }
		int PageSize { get; set; }
		IEnumerable<AirplanePassenger> CurrentPagePassengers { get; }
		string CurrentTime { get; }

	}
}
