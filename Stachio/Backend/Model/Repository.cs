namespace Stachio.Backend.Model;

public sealed class Repository
{
    public RepoConfig repoConfig { get; set; }

    public Repository(User user)
	{
		repoConfig = new RepoConfig(user);
	}

    public Repository(RepoConfig repoConfig)
	{
		this.repoConfig = repoConfig;
	}
}
