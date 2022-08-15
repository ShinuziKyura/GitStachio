using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class UserController
{
    private static UserController userController;

    private UserController()
    {
    }

    public static UserController getInstance()
    {
        if (userController == null)
        {
            userController = new UserController();
        }

        return userController;

    }

}
