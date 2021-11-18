using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Stache.View
{
	public class MainControl : UserControl
	{
		public MainControl()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
