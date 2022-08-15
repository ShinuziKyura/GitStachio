namespace Stachio.Backend.Model;



public sealed class AppConfig
{

    private static AppConfig instance;

	private List<Repository> repos;

	private List<CommandSequence> commandSequences;

	private List<User> users;

    private AppConfig()
	{
		this.repos = new List<Repository>();

		this.commandSequences = new List<CommandSequence>();

		this.users = new List<User>();

	}

    public static AppConfig getInstance()
    {
        if(instance == null)
        {
            instance = new AppConfig();
        }
        return instance;
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
