using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagers
{
    public static class proc_helper
    {
        private static string output;

        public static string Output
        {
            get { return output; }
            set { output = value; }
        }

        public static void ExecuteCommand(string command, string parameters)
        {
            Process process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = parameters;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            Output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            process.Close();
        }
    }
}
