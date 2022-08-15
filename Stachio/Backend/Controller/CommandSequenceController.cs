using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class CommandSequenceController
{
    public static CommandSequenceController getInstance()
    {
        return instance ?? (instance = new CommandSequenceController());
    }

    private static CommandSequenceController instance;

    private CommandSequenceController()
    {
    }
}
