using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepoConfigController
{
    private static RepoConfigController instance;
    
    private RepoConfigController()
    {
    }

    public static RepoConfigController getInstance()
    {
        if(instance == null)
        {
            instance = new RepoConfigController();
        }

        return instance;
    }

}
