namespace Stachio.Backend.Model;

public sealed class RepoConfig
{
    public List<StacheCommandSeq> commandSequenceList { get; private set; }

    public List<User> userList { get; private set; }

    public RepoConfig(User user)
    {
        this.commandSequenceList = new List<StacheCommandSeq>();
        this.userList = new List<User>();

        this.userList.Add(user ?? throw new ArgumentNullException(nameof(user)));
    }

    public RepoConfig(List<StacheCommandSeq> commandSequenceList, List<User> userList)
    {
        this.commandSequenceList = commandSequenceList;
        this.userList = (userList.Count > 0 ? throw new InvalidDataException() : userList);
    }

    public void addCommandSequence(StacheCommandSeq stacheCommandSeq)
    {
        commandSequenceList.Add(stacheCommandSeq ?? throw new ArgumentNullException(nameof(stacheCommandSeq)));
    }

    public bool deleteCommandSequence(StacheCommandSeq stacheCommandSeq)
    {
        return commandSequenceList.Remove(stacheCommandSeq ?? throw new ArgumentNullException(nameof(stacheCommandSeq)));
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
