using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel.Interfaces
{
	public interface ICommandService
	{
		RelayCommand CloseCommand { get; }
		RelayCommand MaxCommand { get; }
		RelayCommand MoveWindowCommand { get; }
		RelayCommand LoadPassengersCommand { get; }
		event Action<IEnumerable<AirplanePassenger>> PassengersLoaded;
	}
}
