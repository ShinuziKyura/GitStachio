using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class AppConfigController
{
    public AppConfig appConfig { get; private set; }

    public static AppConfigController getInstance()
    {
        return instance ?? (instance = new AppConfigController());
    }

    private static AppConfigController instance;

    private AppConfigController()
    {
        //should load File with all the structure
        this.appConfig = AppConfig.getInstance();
    }
}
