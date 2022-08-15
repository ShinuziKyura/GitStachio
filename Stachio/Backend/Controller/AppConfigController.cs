using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class AppConfigController
{
    private AppConfig appConfig;

    private static AppConfigController instance;

    private AppConfigController()
    {
        //should load File with all the structure
        this.appConfig = new AppConfig();
    }

    public AppConfig AppConfig { get => appConfig;}


    public static AppConfigController getInstance()
    {
        if (instance == null)
        {
            instance = new AppConfigController();   
        }

        return instance;
    }
}
