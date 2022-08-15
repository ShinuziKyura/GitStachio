using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class UserController
{
    private AppConfig appConfig;

    private static UserController userController;

    private UserController(AppConfig appConfig)
    {
        this.appConfig = appConfig;
    }

    public static UserController getInstance(AppConfig appConfig)
    {
        if (userController == null)
        {
            userController = new UserController(appConfig);
        }

        return userController;

    }

}
