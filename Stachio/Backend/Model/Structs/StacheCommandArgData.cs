using Stachio.Backend.View;
using Stachio.Backend.View.Enums;

namespace Stachio.Backend.Model.Structs;

public struct StacheCommandArgData
{
    public StacheCommandArgType type;

    public int index;

    public string prefix;
}