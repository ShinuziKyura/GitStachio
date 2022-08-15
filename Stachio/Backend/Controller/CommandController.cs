using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandController
{
    private AppConfig appConfig;

    private static CommandController instance;

    private CommandController(AppConfig appConfig)
    {
        this.appConfig = appConfig;
    }

    public static CommandController getInstance(AppConfig appConfig)
    {
        if (instance == null)
        {
            instance = new CommandController(appConfig);
        }

        return instance;
    }
}
