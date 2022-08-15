namespace Stachio.Backend.Model;

public sealed class User
{

	private string username;

	private string password;

	public User(string username)
	{
		this.username = username;
	}

	public User(string username, string password)
	{
		this.username = username;
		this.password = password;
	}

	public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
}
