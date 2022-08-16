using System.Diagnostics;
using System.Globalization;
using System.Security;

using Stachio.Backend.Model.Enums;

namespace Stachio.Backend.Model;

public sealed class Command
{
    public string descriptiveName { get; private set; }

    public string executablePath { get; private set; }

    // TODO change this to be more... refined
    public string commandOutput { get; private set; }

    public Command(string descriptiveName)
    {
        this.descriptiveName = descriptiveName;
    }

    public bool setExecutablePath(string executablePath)
    {
        bool hasValidPath = isExecutablePathValid(executablePath);
        this.executablePath = hasValidPath ? executablePath : string.Empty;
        return hasValidPath;
    }

    public void setCommandString(string commandString)
    {
        this.commandString = commandString;
    }

    public void addArgument(string argumentPrefix, 
                            ProcessArgumentType argumentType,
                            ProcessArgumentInfixType argumentInfixType = ProcessArgumentInfixType.None)
    {
        int argIndex = numArguments++;
        string argumentFormatString = string.Empty;

        if (argumentType != ProcessArgumentType.Flag)
        {
            ++numRequiredArguments;
            switch (argumentInfixType)
            {
                case ProcessArgumentInfixType.None:
                case ProcessArgumentInfixType.Space:
                    argumentFormatString += " ";
                    break;
                case ProcessArgumentInfixType.Equal:
                    argumentFormatString += "=";
                    break;
                case ProcessArgumentInfixType.Colon:
                    argumentFormatString += ":";
                    break;
            }
        }

        switch (argumentType)
        {
            case ProcessArgumentType.String:
                argumentFormatString += $"{{{argIndex}}}";
                break;
            case ProcessArgumentType.Integer:
                argumentFormatString += $"{{{argIndex}:d}}";
                break;
        }

        commandString += $" {argumentPrefix}{argumentFormatString}";
    }

    public async Task<bool> executeCommandAsync(params object[] arguments)
    {
        using Process process = new();

        // TODO test arguments before?
        var procArgs = string.Format(CultureInfo.InvariantCulture, commandString, arguments);

        process.StartInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = procArgs,
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            UseShellExecute = false,
            //RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            // TODO same for input maybe?
        };

        var onDataReceivedHandler = new DataReceivedEventHandler((sender, dataReceived) =>
        {
            // TODO send output somewhere
            if (dataReceived.Data is not null)
            {
                Debugger.Log(0, "", $"AsyncProcess '{descriptiveName}': {dataReceived.Data}\n");
                
                commandOutput += dataReceived.Data;
            }
        });

        process.OutputDataReceived += onDataReceivedHandler;
        process.ErrorDataReceived += onDataReceivedHandler;

        if (process.Start())
        {
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync().ConfigureAwait(false);

            // TODO send this as output somewhere (maybe log file)
            Debugger.Log(0, "", $"AsyncProcess '{descriptiveName}' has exited with code {process.ExitCode}\n");

            return true;
        }
        else
        {
            // TODO log failure to start process somewhere
        }

        return false;
    }

    private string commandString;

    private int numArguments;
    private int numRequiredArguments;

    private static bool isExecutablePathValid(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            // TODO file path can't be empty, warn the user
            return false;
        }

        if (!Path.IsPathRooted(filePath))
        {
            // TODO only accept absolute file path, warn the user
            return false;
        }

        FileInfo fileInfo = null;

        try
        {
            fileInfo = new FileInfo(filePath);
        }
        catch (SecurityException)
        {
            // TODO user doesn't have permission, do smth (warn and maybe prompt for higher perms)
        }
        catch (UnauthorizedAccessException)
        {
            // TODO user also doesn't have permission? test to see diff from SecurityException
        }
        catch (PathTooLongException)
        {
            // TODO this is shitty, warn the user
        }
        catch (Exception ex) when (ex is ArgumentException or NotSupportedException)
        {
            // TODO invalid path, warn the user
        }

        bool isValid = fileInfo is not null;

        if (isValid && !fileInfo.Exists)
        {
            // TODO file does not exist or is a directory, warn the user
            return false;
        }

        return isValid;
    }

}
