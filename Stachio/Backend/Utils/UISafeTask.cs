using System.Runtime.CompilerServices;

namespace Stachio.Backend.Utils;

public static class UISafeTask
{
    // Asynchronous functions
    public static ConfiguredTaskAwaitable<T> Run<T>(Func<Task<T>> func)
    {
        return Task.Run(func).ConfigureAwait(false);
    }
    public static ConfiguredTaskAwaitable Run(Func<Task> func)
    {
        return Task.Run(func).ConfigureAwait(false);
    }

    // Synchronous functions
    public static ConfiguredTaskAwaitable<T> Run<T>(Func<T> func)
    {
        return Task.Run(func).ConfigureAwait(false);
    }
    public static ConfiguredTaskAwaitable Run(Action func)
    {
        return Task.Run(func).ConfigureAwait(false);
    }
}