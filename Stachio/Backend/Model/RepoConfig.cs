namespace Stachio.Backend.Model;

public sealed class RepoConfig
{
    private List<CommandSequence> commandSequences;

    private List<User> users;

    public RepoConfig(User user)
    {
        this.commandSequences = new List<CommandSequence>();
        this.users = new List<User>();

        this.users.Add(user?? throw new ArgumentNullException(nameof(user)));
    }

    public RepoConfig(List<CommandSequence> commandSequences, List<User> users)
    {
        this.commandSequences = commandSequences;
        this.users=users.Count > 0? throw new InvalidDataException() : users;
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

    public List<CommandSequence> CommandSequences { get => commandSequences; set => commandSequences = value; }
    public List<User> Users { get => users; set => users = value; }
}
