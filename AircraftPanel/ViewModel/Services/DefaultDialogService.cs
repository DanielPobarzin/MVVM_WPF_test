using Microsoft.Win32;
using System.Windows;
using ViewModel.Interfaces;

namespace ViewModel.Services
{
    public class DefaultDialogService : IDialogService
	{
		public void ShowMessage(string message)
		{
			MessageBox.Show(message);
		}

		public string FilePath { get; set; }
		public bool OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				FilePath = openFileDialog.FileName;
				return true;
			}

			return false;
		}
	}
}
