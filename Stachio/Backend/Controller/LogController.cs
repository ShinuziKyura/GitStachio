using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class LogController
{

    private static LogController instance;

    private LogController()
    {
    }

    public static LogController getInstantce()
    {
        if(instance == null)
        {
            instance = new LogController(); 
        }

        return instance;
    }
}
