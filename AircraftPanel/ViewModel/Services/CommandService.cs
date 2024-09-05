using FluentValidation;
using Models.DTOs;
using Serilog;
using System.Windows;
using ViewModel.Commands;
using ViewModel.Interfaces;

namespace ViewModel.Services
{
	public class CommandService : ICommandService
	{
		private readonly IDialogService _dialogService;
		private readonly IFileService<AirplanePassenger> _fileService;
		private readonly IValidator<AirplanePassenger> _validator;

		private readonly Lazy<RelayCommand> _closeCommand;
		private readonly Lazy<RelayCommand> _maxCommand;
		private readonly Lazy<RelayCommand> _moveWindowCommand;
		private readonly Lazy<RelayCommand> _loadPassengersCommand;

		public CommandService(IDialogService dialogService,
							  IFileService<AirplanePassenger> fileService,
							  IValidator<AirplanePassenger> validator)
		{
			_dialogService = dialogService;
			_fileService = fileService;
			_validator = validator;

			_closeCommand = new Lazy<RelayCommand>(() => new RelayCommand(CloseApp));
			_maxCommand = new Lazy<RelayCommand>(() => new RelayCommand(MaxApp));
			_moveWindowCommand = new Lazy<RelayCommand>(() => new RelayCommand(OnMoveWindow));
			_loadPassengersCommand = new Lazy<RelayCommand>(() => new RelayCommand(LoadPassengers));
		}

		public RelayCommand CloseCommand => _closeCommand.Value;
		public RelayCommand MaxCommand => _maxCommand.Value;
		public RelayCommand MoveWindowCommand => _moveWindowCommand.Value;
		public RelayCommand LoadPassengersCommand => _loadPassengersCommand.Value;

		public event Action<IEnumerable<AirplanePassenger>> PassengersLoaded;
		private static void CloseApp(object obj)
        {
            if (obj is Window win)
            {
                win.Close();
            }
        }

        private static void MaxApp(object obj)
        {
            if (obj is Window win)
            {
                win.WindowState = win.WindowState == WindowState.Normal ?
                    WindowState.Maximized : WindowState.Normal;
            }
        }
        private static void OnMoveWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.DragMove();
            }
        }

		private async void LoadPassengers(object obj)
		{
			try
			{
				if (_dialogService.OpenFileDialog() == true)
				{
					var passengers = await Task.Run(() => _fileService.Open(_dialogService.FilePath));
					_dialogService.ShowMessage("File has been opened successfully.");
					Log.Information("The data from the file has been received.");
					var validPassengers = new List<AirplanePassenger>();
					var validationTasks = new List<Task>();

					foreach (var passenger in passengers)
					{
						validationTasks.Add(Task.Run(() =>
						{
							if (_validator?.Validate(passenger) is { IsValid: false } validationResult)
							{
								foreach (var error in validationResult.Errors)
								{
									Log.Warning($"Validation failed for passenger {passenger.Passenger.FirstName} {passenger.Passenger.LastName} " +
										$"\n\t- {error.PropertyName}: {error.ErrorMessage}");
								}
							}
							else
							{
								lock (validPassengers) 
								{
									validPassengers.Add(passenger);
								}
							}
						}));
					}
					await Task.WhenAll(validationTasks);

						PassengersLoaded?.Invoke(validPassengers);

				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}
		private void HandleError(Exception ex)
		{
			_dialogService.ShowMessage(ex.Message);
			Log.Error("An error occurred: {0}", ex.Message);
		}
	}
}