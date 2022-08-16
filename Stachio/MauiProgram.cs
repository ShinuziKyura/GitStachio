using System.Diagnostics;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Stachio.Backend.Controller;
using Stachio.Backend.Model.Enums;
using Stachio.Frontend.Shared;
using Command = Stachio.Backend.Model.Command;

namespace Stachio;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddSingleton<BigStachioController>();

        // TODO some test code, remove this once done
        {
            var command = new Command("Git Version");

            var execPath = "C:\\Program Files\\Git\\cmd\\git.exe";
            var commandString = "";
            var commandArg = "--version";
            command.setExecutablePath(execPath);
            command.setCommandString(commandString);
            command.addArgument(commandArg, ProcessArgumentType.Flag);

            var result = command.executeCommandAsync();
            Task.WaitAll(result);
        }

        return builder.Build();
    }
}
