using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Container
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Not enough arguments");
            }

            switch (args[0])
            {
                case "run":
                    {
                        Run(args.Skip(1));
                        break;
                    }
                default:
                    throw new InvalidOperationException("WAT?");
            }

        }

        private static void Run(IEnumerable<string> args)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = args.First();
            processInfo.Arguments = string.Join(" ", args.Skip(1));
            var process = new Process{ StartInfo = processInfo};
            process.Start();
            process.WaitForExit();
        }
    }
}
