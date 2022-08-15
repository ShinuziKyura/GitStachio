using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class UserController
{
    public static UserController getInstance()
    {
        return userController ?? (userController = new UserController());
    }

    private static UserController userController;

    private UserController()
    {
    }
}
