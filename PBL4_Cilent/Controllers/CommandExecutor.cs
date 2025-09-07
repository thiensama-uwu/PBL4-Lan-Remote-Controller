using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL4_Cilent.Controllers
{
    public class CommandExecutor
    {
        public void Execute(string cmd)
        {
            switch (cmd.ToUpper())
            {
                case "SHUTDOWN":
                    Shutdown();
                    break;
                case "RESTART":
                    Restart();
                    break;
                case "SCREENSHOT":
                    Screenshot();
                    break;
                default:
                    Console.WriteLine("Unknown command: " + cmd);
                    break;
            }
        }

        private static void Shutdown()
        {
            Console.WriteLine("Shutting down...");
            Process.Start("shutdown", "/s /t 0");
        }

        private static void Restart()
        {
            Console.WriteLine("Restarting...");
            Process.Start("shutdown", "/r /t 0");
        }

        private static void Screenshot()
        {
            Console.WriteLine("Capturing screenshot...");
            // TODO: chụp màn hình và gửi về server
        }
    }
}
