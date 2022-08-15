namespace Stachio.Backend.Model;

public sealed class Command
{
	private string commandString;

    public Command(string commandString)
    {
        this.commandString = commandString;
    }

    public string CommandString { get => commandString; set => commandString = value; }
}
