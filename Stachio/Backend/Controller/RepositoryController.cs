using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepositoryController
{
    private static RepositoryController instance;

    private RepositoryController()
    {
    }

    public static RepositoryController getInstance()
    {
        if (instance == null)
        {
            instance = new RepositoryController();
        }

        return instance;

    }

}
