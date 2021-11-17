using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Backend.Model.Services
{
    public class GitExecutionService
    {
        public async Task RequestCommand(string command)
        {
            await Task.Run(() => Process.Start("", command));
        }
    }
}
