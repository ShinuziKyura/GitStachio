namespace Stachio.Backend.Model;

public sealed class Command
{
    public string commandString { get; set; }

    public Command(string commandString)
    {
        this.commandString = commandString;
    }
}
