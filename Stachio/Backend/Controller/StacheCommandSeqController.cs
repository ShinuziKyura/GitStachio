using Stachio.Backend.Model;

namespace Stachio.Backend.Controller;

public sealed class StacheCommandSeqController
{
    public static StacheCommandSeqController GetInstance()
    {
        return instance;
    }

    private static StacheCommandSeqController instance = new();

    private StacheCommandSeqController()
    {
    }
}
