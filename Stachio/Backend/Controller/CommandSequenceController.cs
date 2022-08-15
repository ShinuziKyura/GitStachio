using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandSequenceController
{
    private AppConfig appConfig;

    private static CommandSequenceController instance;
    
    private CommandSequenceController(AppConfig appConfig)
    {
        this.appConfig = appConfig;
    }

    public static CommandSequenceController getInstance(AppConfig appConfig)
    {
        if (instance == null)
        {
            instance = new CommandSequenceController(appConfig);
        }

        return instance;

    }

}
