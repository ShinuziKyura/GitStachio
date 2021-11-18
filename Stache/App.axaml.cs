using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System.Threading.Tasks;

using Stache.View;
using Stache.ViewModel;

namespace Stache
{
	internal class Model
	{
		public void Initialize()
		{

		}
	}

	public class App : Application
	{
		public override void Initialize()
		{
			InitializeComponent();

			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				// Initialize whatever necessary with desktop.Args
			}

			_model = new Model();

			Task.Run(() => _model.Initialize());
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				desktop.MainWindow = new MainWindow
				{
					DataContext = new MainWindowViewModel(),
				};
			}

			base.OnFrameworkInitializationCompleted();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private Model? _model;
	}
}
