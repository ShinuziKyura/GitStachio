using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class RepoConfigController
{
    private AppConfig appConfig;

    private static RepoConfigController instance;
    
    private RepoConfigController(AppConfig appConfig)
    {
        this.appConfig = appConfig;
    }

    public static RepoConfigController getInstance(AppConfig appConfig)
    {
        if(instance == null)
        {
            instance = new RepoConfigController(appConfig);
        }

        return instance;
    }

}
