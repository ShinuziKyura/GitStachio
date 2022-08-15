namespace Stachio.Backend.Model;

public sealed class CommandSequence
{
    public List<Command> commandList { get; private set; }

    public CommandSequence()
	{
		commandList = new List<Command>(); 
	}

    public CommandSequence(List<Command> commandList)
	{
		this.commandList = commandList;
	}

    public void addCommand(Command command)
    {
        commandList.Add(command ?? throw new ArgumentNullException(nameof(command)));
    }

    public bool deleteCommand(Command command)
    {
        return commandList.Remove(command ?? throw new ArgumentNullException(nameof(command)));
    }
}
