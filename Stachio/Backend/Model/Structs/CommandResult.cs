namespace Stachio.Backend.Model.Structs;

public struct CommandResult
{
    public bool hasExecuted;

    public int exitCode;

    public TimeSpan executionTime;

    public string output;
}