using System.Windows;
using System.Windows.Input;
using ViewModel;
using ViewModel.Interfaces;

namespace ApplicationPanel
{
	public partial class MainWindow : Window
	{
		private IApplicationViewModel _viewModel;

		public MainWindow()
		{
			InitializeComponent();
		}

		public void SetViewModel(IApplicationViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel; 
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

