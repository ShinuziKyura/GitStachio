namespace Stachio.Backend.Model;

public sealed class Repository
{

	private RepoConfig repoConfig;

	public Repository(User user)
	{
		repoConfig = new RepoConfig(user);
	}

	public Repository(RepoConfig repoConfig)
	{
		this.repoConfig = repoConfig;
	}

	public RepoConfig RepoConfig { get => repoConfig; set => repoConfig = value; }
}
