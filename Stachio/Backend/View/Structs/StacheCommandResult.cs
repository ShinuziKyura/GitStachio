namespace Stachio.Backend.View.Structs;

public struct StacheCommandResult
{
    public bool hasExecuted;

    public int exitCode;

    public TimeSpan executionTime;

    public string output;
}