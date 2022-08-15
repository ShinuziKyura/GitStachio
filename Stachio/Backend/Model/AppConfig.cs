namespace Stachio.Backend.Model;

public sealed class AppConfig
{
    public List<CommandSequence> commandSequenceList { get; private set; }

    public List<Repository> repoList { get; private set; }

    public List<User> userList { get; private set; }

    public static AppConfig getInstance()
    {
        return instance ?? (instance = new AppConfig());
    }

    public void addCommandSequence(CommandSequence commandSequence)
    {
        commandSequenceList.Add(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

    public bool deleteCommandSequence(CommandSequence commandSequence)
    {
        return commandSequenceList.Remove(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

    public void addRepository(Repository repo)
	{
        repoList.Add(repo ?? throw new ArgumentNullException(nameof(repo)));
	}

	public bool deleteRepository(Repository repo)
	{
		return repoList.Remove(repo ?? throw new ArgumentNullException(nameof(repo)));
    }

    public void addUser(User user)
    {
        userList.Add(user ?? throw new ArgumentNullException(nameof(user)));
    }

    public bool deleteUser(User user)
    {
        return userList.Remove(user ?? throw new ArgumentNullException(nameof(user)));
    }

    private static AppConfig instance;

    private AppConfig()
    {
        this.repoList = new List<Repository>();

        this.userList = new List<User>();

        this.commandSequenceList = new List<CommandSequence>();

    }
}
