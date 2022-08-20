using Stachio.Backend.Model.Enums;

namespace Stachio.Backend.Model.Structs;

public struct CommandArgumentData
{
    public CommandArgumentType type;

    public int index;

    public string prefix;
}