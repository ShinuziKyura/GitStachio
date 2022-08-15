using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepoConfigController
{
    public static RepoConfigController getInstance()
    {
        return instance ?? (instance = new RepoConfigController());
    }

    private static RepoConfigController instance;

    private RepoConfigController()
    {
    }
}
