using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Runtime.InteropServices;
using System.Windows;
using ViewModel;
using ViewModel.Interfaces;
using ViewModel.Services;
using ViewModel.ViewModelValidator;

namespace ApplicationPanel
{
	public partial class App : Application
	{
		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();
		public static IServiceProvider ServiceProvider { get; private set; }

		public App()
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			ServiceProvider = services.BuildServiceProvider();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IFileService<AirplanePassenger>, JsonFileService>();
			services.AddSingleton<IValidator<AirplanePassenger>, AirplanePassengerValidator>();
			services.AddSingleton<IDialogService, DefaultDialogService>();
			services.AddSingleton<IDateTimeService, DateTimeService>();
			services.AddSingleton<ICommandService, CommandService>();

			services.AddSingleton<IApplicationViewModel, ApplicationViewModel>();

			services.AddSingleton<MainWindow>();

		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			AllocConsole();
			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.Console(theme: SystemConsoleTheme.Colored, restrictedToMinimumLevel: LogEventLevel.Information)
			.CreateLogger();
			Log.Information("Start application...");

			ServiceProvider.GetRequiredService<MainWindow>().SetViewModel(ServiceProvider.GetRequiredService<IApplicationViewModel>());
			ServiceProvider.GetRequiredService<MainWindow>().Show();
		}
		protected override void OnExit(ExitEventArgs e)
		{
			Log.Information("Close application...");
			Log.CloseAndFlush();
			base.OnExit(e);
		}
	}
}






