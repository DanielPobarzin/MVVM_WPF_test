using Models.DTOs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using ViewModel.Commands;
using ViewModel.Helpers;
using ViewModel.Interfaces;
using ViewModel.ViewModelValidator;

namespace ViewModel
{
	public class ApplicationViewModel : IApplicationViewModel
	{
		private readonly IDateTimeService _dateTimeService;
		private readonly ICommandService _commandService;

		public RelayCommand CloseCommand => _commandService.CloseCommand;
		public RelayCommand MaxCommand => _commandService.MaxCommand;
		public RelayCommand MoveWindowCommand => _commandService.MoveWindowCommand;
		public RelayCommand LoadPassengersCommand => _commandService.LoadPassengersCommand;

		private System.Timers.Timer _timerTime;
		private System.Timers.Timer _timerPaging;
		private string _currentTime;
		private bool _isFirstLoad = true;

		public ObservableCollection<AirplanePassenger> Passengers { get; private set; }
		public int CurrentPage { get; private set; }
		public int PageSize { get; set; } = 15;
		public AirplanePassengerValidator Validator { get; }

		public IEnumerable<AirplanePassenger> CurrentPagePassengers =>
			Passengers.Skip(CurrentPage * PageSize).Take(PageSize);
		public string CurrentTime
		{
			get => _currentTime;
			set
			{
				_currentTime = value;
				OnPropertyChanged();
			}
		}

		public ApplicationViewModel(IDateTimeService dateTimeService, ICommandService commandService)
		{
			StartTimer();
			TestGenerate.Generate();
			Passengers = new ObservableCollection<AirplanePassenger>();
			
			_dateTimeService = dateTimeService;
			_commandService = commandService;
			_commandService.PassengersLoaded += OnPassengersLoaded;
        }

		private void UpdatePage()
		{
			Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				int totalPages = (Passengers.Count + PageSize - 1) / PageSize;
				CurrentPage = (CurrentPage + 1) % totalPages;
				OnPropertyChanged(nameof(CurrentPagePassengers));
			}));
			
		}

		private void OnPassengersLoaded(IEnumerable<AirplanePassenger> passengers)
		{

			Passengers.Clear();
			foreach (var passenger in passengers)
			{
				Passengers.Add(passenger);
			}
			_timerPaging = new(5000);
			_timerPaging.Elapsed += (s, e) => UpdatePage();
			_timerPaging.Start();
			if (_isFirstLoad)
			{
				UpdatePage();
				_isFirstLoad = false;
			}
		}

		private void StartTimer()
		{
			_timerTime = new(1000);
			_timerTime.Elapsed += UpdateTime;
			_timerTime.Start();
		}
		private void UpdateTime(object? sender, ElapsedEventArgs e)
		{
			Application.Current.Dispatcher.BeginInvoke(new Action(() =>
			{
				CurrentTime = _dateTimeService.Now.ToString("HH:mm:ss");
			}));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
		}
    }
}
