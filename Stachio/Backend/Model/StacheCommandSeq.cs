namespace Stachio.Backend.Model;

public sealed class StacheCommandSeq
{
    public List<StacheCommand> commandList { get; private set; }

    public StacheCommandSeq()
	{
		commandList = new List<StacheCommand>(); 
	}

    public StacheCommandSeq(List<StacheCommand> commandList)
	{
		this.commandList = commandList;
	}

    public void AddCommand(StacheCommand command)
    {
        commandList.Add(command ?? throw new ArgumentNullException(nameof(command)));
    }

    public bool DeleteCommand(StacheCommand command)
    {
        return commandList.Remove(command ?? throw new ArgumentNullException(nameof(command)));
    }
}
