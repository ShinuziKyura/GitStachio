using Stachio.Backend.Model;
using Stachio.Backend.Model.Enums;
using Stachio.Backend.Utils;
using Stachio.Backend.View;
using System.ComponentModel.Design;
using Stachio.Backend.View.Enums;
using Stachio.Backend.View.Structs;

namespace Stachio.Backend.Controller;

public sealed class StacheCommandController
{
    public static StacheCommandController GetInstance()
    {
        return instance;
    }

    public Guid MakeGitCommand(string gitCommand, string gitSubCommand = "")
    {
        var command = new StacheCommand(gitCommand);

        if (!command.ConfigureExecutablePath(gitExecutablePath))
        {
            // TODO error out
            return Guid.Empty;
        }

        command.SetCommandString(gitSubCommand);

        if (!commandRegistry.Add(command))
        {
            // TODO error out (this should not ever happen, so a generic "oops, something wrong, try again" should be enough)
            return Guid.Empty;
        }

        return command.uniqueId;
    }

    public bool AddGitCommandFlag(Guid commandId, string argumentName, StacheCommandArgType argumentType)
    {
        if (FindGitCommandInRegistry(commandId, out var command))
        {
            command!.AddCommandArgument(argumentName, argumentType);
            return true;
        }

        return false;
    }

    public async Task<StacheCommandResult> ExecuteGitCommandAsync(Guid commandId, params object[] arguments)
    {
        if (FindGitCommandInRegistry(commandId, out var command))
        {
            return await UISafeTask.Run(async () => await command!.ExecuteCommandAsync(arguments));
        }

        return new StacheCommandResult();
    }

    private static StacheCommandController instance = new();

    private HashSet<StacheCommand> commandRegistry;

    private string gitExecutablePath;

    private StacheCommandController()
    {
        commandRegistry = new();

        // TODO do this better at some point (get it from PATH?)
        gitExecutablePath = @"C:\Program Files\Git\cmd\git.exe";
    }

    private bool FindGitCommandInRegistry(Guid commandId, out StacheCommand? command)
    {
        if (!commandRegistry.TryGetValue(new StacheCommand(commandId), out command))
        {
            command = null; 
            return false;
        }

        if (command.executablePath != gitExecutablePath)
        {
            command = null;
            return false;
        }

        return true;
    }
}
