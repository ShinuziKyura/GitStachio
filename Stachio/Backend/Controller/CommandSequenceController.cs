using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandSequenceController
{

    private static CommandSequenceController instance;
    
    private CommandSequenceController()
    {
    }

    public static CommandSequenceController getInstance()
    {
        if (instance == null)
        {
            instance = new CommandSequenceController();
        }

        return instance;

    }

}
