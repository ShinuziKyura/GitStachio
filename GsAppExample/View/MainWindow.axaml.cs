using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace GsAppExample.View
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
	        AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void OnHelloBTClicked(object sender, RoutedEventArgs args)
        {
	        var button = (Button) sender;
	        button.Content = "Hello, Avalonia!";
        }
    }
}
