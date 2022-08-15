using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepositoryController
{
    public static RepositoryController getInstance()
    {
        return instance ?? (instance = new RepositoryController());
    }

    private static RepositoryController instance;

    private RepositoryController()
    {
    }
}
