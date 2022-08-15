using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandController
{

    private static CommandController instance;

    private CommandController()
    {
    }

    public static CommandController getInstance()
    {
        if (instance == null)
        {
            instance = new CommandController();
        }

        return instance;
    }
}
