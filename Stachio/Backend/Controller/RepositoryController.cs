using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepositoryController
{
    private AppConfig appConfig;

    private static RepositoryController instance;

    private RepositoryController(AppConfig appConfig)
    {
        this.appConfig = appConfig;
    }

    public static RepositoryController getInstance(AppConfig appConfig)
    {
        if (instance == null)
        {
            instance = new RepositoryController(appConfig);
        }

        return instance;

    }

}
