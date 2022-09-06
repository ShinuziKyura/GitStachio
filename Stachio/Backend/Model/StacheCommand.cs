using System.Diagnostics;
using System.Globalization;
using System.Text;

using Stachio.Backend.Model.Enums;
using Stachio.Backend.Model.Structs;
using Stachio.Backend.View.Enums;
using Stachio.Backend.View.Structs;

namespace Stachio.Backend.Model;

public class StacheCommand
{
    // TODO replace this for something more meaningful later (maybe a uniqueName string built using descriptiveName?)
    // TODO make commands more searchable in the registry
    public Guid uniqueId { get; }

    public string descriptiveName { get; }

    public string executablePath { get; private set; }

    public StacheCommand(Guid newUniqueId) // Only used for comparison
    {
        uniqueId = newUniqueId;
        
        descriptiveName = null!;
        executablePath = null!;

        commandString = null!;
        commandArgumentList = null!;
    }

    public StacheCommand(string newDescriptiveName)
    {
        uniqueId = Guid.NewGuid();
        descriptiveName = newDescriptiveName;
        executablePath = string.Empty;

        commandString = string.Empty;
        cachedCommandStringFormat = null;
        commandArgumentList = new();
        numFormatArguments = 0;
    }

    public bool ConfigureExecutablePath(string newExecutablePath)
    {
        bool hasValidPath = File.Exists(newExecutablePath);
        executablePath = hasValidPath ? newExecutablePath : string.Empty;
        return hasValidPath;
    }

    public bool HasValidExecutablePath()
    {
        return executablePath != string.Empty;
    }

    public string GetCommandString()
    {
        return commandString;
    }

    public void SetCommandString(string newCommandString)
    {
        cachedCommandStringFormat = null;
        commandString = newCommandString;
    }

    public IEnumerable<StacheCommandArgData> GetCommandArgumentList()
    {
        return commandArgumentList;
    }

    public StacheCommandArgData GetCommandArgument(int index)
    {
        return commandArgumentList[index];
    }

    public int AddCommandArgument(string argumentPrefix,
                                  StacheCommandArgType argumentType,
                                  StacheCommandArgInfixType argumentInfixType = StacheCommandArgInfixType.Space)
    {
        int index = commandArgumentList.Count;

        int argumentIndex = -1;
        if (argumentType != StacheCommandArgType.Flag)
        {
            argumentIndex = numFormatArguments++;
            switch (argumentInfixType)
            {
                case StacheCommandArgInfixType.Space:
                    if (argumentPrefix != string.Empty)
                    {
                        argumentPrefix += " ";
                    }
                    break;
                case StacheCommandArgInfixType.Equal:
                    argumentPrefix += "=";
                    break;
                case StacheCommandArgInfixType.Colon:
                    argumentPrefix += ":";
                    break;
            }
        }

        cachedCommandStringFormat = null;
        commandArgumentList.Add(new StacheCommandArgData
        {
            type = argumentType,
            index = argumentIndex,
            prefix = argumentPrefix,
        });

        return index;
    }

    public void RemoveCommandArgument(int index)
    {
        var commandData = commandArgumentList[index];
        if (commandData.index != -1)
        {
            --numFormatArguments;
        }

        commandArgumentList.RemoveAt(index);
    }

    public async Task<StacheCommandResult> ExecuteCommandAsync(params object[] arguments)
    {
        using Process process = new();

        if (arguments.Length < numFormatArguments)
        {
            throw new ArgumentException($"Number of passed arguments [{arguments.Length}] does not match the configured arguments [{numFormatArguments}]",
                nameof(arguments));
        }

        if (cachedCommandStringFormat is null)
        {
            cachedCommandStringFormat = BuildCachedCommandString(arguments);
        }

        var executableArgs = string.Format(CultureInfo.InvariantCulture, cachedCommandStringFormat, arguments);

        process.StartInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = executableArgs,
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            UseShellExecute = false,
            //RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };

        StringBuilder commandOutput = new();

        var onDataReceivedHandler = new DataReceivedEventHandler((sender, dataReceived) =>
        {
            if (dataReceived.Data is not null)
            {
#if DEBUG
                Debugger.Log(0, "info", $"Command '{descriptiveName}': {dataReceived.Data}\n");
#endif

                commandOutput.AppendLine(dataReceived.Data);
            }
        });

        process.OutputDataReceived += onDataReceivedHandler;
        process.ErrorDataReceived += onDataReceivedHandler;

        if (process.Start())
        {
#if DEBUG
            Debugger.Log(0, "info", $"Command '{descriptiveName}' has started.\n");
#endif

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

#if DEBUG
            Debugger.Log(0, "info", $"Command '{descriptiveName}' has exited with code {process.ExitCode} (0x{process.ExitCode:x8}).\n");
#endif

            return new StacheCommandResult
            {
                hasExecuted = true,
                exitCode = process.ExitCode,
                executionTime = process.TotalProcessorTime,
                output = commandOutput.ToString(),
            };
        }
#if DEBUG
        else
        {
            Debugger.Log(0, "info", $"Command '{descriptiveName}' has failed to start.\n");
        }
#endif

        return new StacheCommandResult
        {
            hasExecuted = false,
            exitCode = int.MinValue,
            executionTime = TimeSpan.Zero,
            output = string.Empty,
        };
    }

    public override bool Equals(object? obj)
    {
        return obj is StacheCommand command && uniqueId == command.uniqueId;
    }

    public override int GetHashCode()
    {
        return uniqueId.GetHashCode();
    }

    private string commandString;

    private string? cachedCommandStringFormat;

    private readonly List<StacheCommandArgData> commandArgumentList;

    private int numFormatArguments;

    private string BuildCachedCommandString(object[] arguments)
    {
        StringBuilder commandStringFormat = new(commandString);

        foreach (var commandArgument in commandArgumentList)
        {
            bool valid = true;

            if (commandArgument.index != -1)
            {
                object argument = arguments[commandArgument.index];
                switch (commandArgument.type)
                {
                    //case CommandArgumentType.ToggleableFlag:
                    case StacheCommandArgType.Boolean:
                        valid = argument is bool;
                        break;
                    case StacheCommandArgType.Integer:
                        valid = argument is sbyte or short or int or long
                                         or byte or ushort or uint or ulong;
                        break;
                    case StacheCommandArgType.String:
                        valid = argument is string || argument.ToString() is not null;
                        break;
                }
            }

            if (!valid)
            {
                throw new ArgumentException($"Invalid passed argument at index '{commandArgument.index}'");
            }

            if (commandArgument.prefix != string.Empty)
            {
                commandStringFormat.Append(' ')
                                   .Append(commandArgument.prefix);
            }

            if (commandArgument.index != -1)
            {
                commandStringFormat.Append('{')
                                   .Append(commandArgument.index)
                                   .Append('}');
            }
        }

        return commandStringFormat.ToString();
    }
}
