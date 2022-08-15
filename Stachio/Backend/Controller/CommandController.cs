using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandController
{
    public static CommandController getInstance()
    {
        return instance ?? (instance = new CommandController());
    }

    private static CommandController instance;

    private CommandController()
    {
    }
}
