using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class LogController
{
    public static LogController getInstance()
    {
        return instance ?? (instance = new LogController());
    }

    private static LogController instance;

    private LogController()
    {
    }
}
