using System.ComponentModel;

namespace GsFrontend.ViewModel
{
	public class MainWindowViewModel : IViewModelBase
	{
		public string Greeting => "Welcome to Avalonia!";

		public event PropertyChangedEventHandler? PropertyChanged;
	}
}
