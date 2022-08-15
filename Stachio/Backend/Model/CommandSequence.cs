using Microsoft.Maui.Controls;

namespace Stachio.Backend.Model;

public sealed class CommandSequence
{
	private List<Command> commands;


	public CommandSequence()
	{
		commands = new List<Command>(); 
	}

	public CommandSequence(List<Command> commands)
	{
		this.commands = commands;
	}


    public void addCommand(Command command)
    {
        commands.Add(command ?? throw new ArgumentNullException(nameof(command)));
    }

    public bool deleteCommand(Command command)
    {
        return commands.Remove(command ?? throw new ArgumentNullException(nameof(command)));
    } 


    public List<Command> Commands { get => commands; set => commands = value; }
}
