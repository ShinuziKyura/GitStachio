namespace Stachio.Backend.Model;

public sealed class User
{
    public string username { get; set; }

    public string password { get; set; }

    public User(string username)
	{
		this.username = username;
	}

    public User(string username, string password)
	{
		this.username = username;
		this.password = password;
    }
}
