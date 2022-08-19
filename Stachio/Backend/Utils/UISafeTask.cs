namespace Stachio.Backend.Utils;

public static class UISafeTask
{
    // Asynchronous functions
    public static async Task<T> Run<T>(Func<Task<T>> func)
    {
        return await Task.Run(func).ConfigureAwait(false);
    }
    public static async Task Run(Func<Task> func)
    {
        await Task.Run(func).ConfigureAwait(false);
    }

    // Synchronous functions
    public static async Task<T> Run<T>(Func<T> func)
    {
        return await Task.Run(func).ConfigureAwait(false);
    }
    public static async Task Run(Action func)
    {
        await Task.Run(func).ConfigureAwait(false);
    }
}