namespace Stachio.Backend.Model;



public sealed class AppConfig
{
	private List<Repository> repos;

	private List<CommandSequence> commandSequences;

	private List<User> users;

    public AppConfig()
	{
		this.repos = new List<Repository>();

		this.commandSequences = new List<CommandSequence>();

		this.users = new List<User>();

	}

	public AppConfig(List<Repository> repos, List<CommandSequence> commandSequences, List<User> users)
	{
		this.repos = repos ?? throw new ArgumentNullException(nameof(repos));
		this.commandSequences = commandSequences ?? throw new ArgumentNullException(nameof(commandSequences));
		this.users = users ?? throw new ArgumentNullException(nameof(users));
	}

	public void addRepository(Repository repo)
	{
        repos.Add(repo ?? throw new ArgumentNullException(nameof(repo)));
	}

	public bool deleteRepository(Repository repo)
	{
		return repos.Remove(repo ?? throw new ArgumentNullException(nameof(repo)));
	}

    public void addCommandSequence(CommandSequence commandSequence)
    {
        commandSequences.Add(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

    public bool deleteCommandSequence(CommandSequence commandSequence)
    {
        return commandSequences.Remove(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

	public void addUser(User user)
    {
        users.Add(user ?? throw new ArgumentNullException(nameof(user)));
    }

    public bool deleteUser(User user)
    {
        return users.Remove(user ?? throw new ArgumentNullException(nameof(user)));
    }


    public List<Repository> Repos { get => repos; set => repos = value; }
    public List<CommandSequence> CommandSequences { get => commandSequences; set => commandSequences = value; }
    public List<User> Users { get => users; set => users = value; }


}
