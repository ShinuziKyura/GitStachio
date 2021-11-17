using System.ComponentModel;

namespace GsAppExample.ViewModel
{
	public class MainWindowViewModel : IViewModelBase
    {
	    public event PropertyChangedEventHandler PropertyChanged;

	    public void OnButtonClicked() => ButtonText = "Hello, Avalonia!";

        public string ButtonText
        {
	        get => _buttonText;
            set
            {
	            _buttonText = value;
	            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonText)));
            }
        }

        private string _buttonText = "Click Me!";

    }
}
