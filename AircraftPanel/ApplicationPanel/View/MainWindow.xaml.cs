using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;
using ViewModel;

namespace ApplicationPanel
{
	public partial class MainWindow : Window
	{
		public MainWindow() : this(App.ServiceProvider.GetRequiredService<ApplicationViewModel>())
		{
		}
		public MainWindow(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}

		private void MovingWin(object sender, MouseButtonEventArgs e)
		{
			if (e.ButtonState == MouseButtonState.Pressed)
			{
				var command = ((ApplicationViewModel)DataContext).MoveWindowCommand;
				if (command.CanExecute(this))
				{
					command.Execute(this);
				}
			}
		}
	}
}

