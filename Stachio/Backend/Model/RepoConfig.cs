namespace Stachio.Backend.Model;

public sealed class RepoConfig
{
    public List<CommandSequence> commandSequenceList { get; private set; }

    public List<User> userList { get; private set; }

    public RepoConfig(User user)
    {
        this.commandSequenceList = new List<CommandSequence>();
        this.userList = new List<User>();

        this.userList.Add(user ?? throw new ArgumentNullException(nameof(user)));
    }

    public RepoConfig(List<CommandSequence> commandSequenceList, List<User> userList)
    {
        this.commandSequenceList = commandSequenceList;
        this.userList = (userList.Count > 0 ? throw new InvalidDataException() : userList);
    }

    public void addCommandSequence(CommandSequence commandSequence)
    {
        commandSequenceList.Add(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

    public bool deleteCommandSequence(CommandSequence commandSequence)
    {
        return commandSequenceList.Remove(commandSequence ?? throw new ArgumentNullException(nameof(commandSequence)));
    }

    public void addUser(User user)
    {
        userList.Add(user ?? throw new ArgumentNullException(nameof(user)));
    }

    public bool deleteUser(User user)
    {
        return userList.Remove(user ?? throw new ArgumentNullException(nameof(user)));
    }
}
