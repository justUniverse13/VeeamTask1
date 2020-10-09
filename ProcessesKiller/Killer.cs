using System;
using System.Diagnostics;
using System.Threading;


namespace ProcessesKiller
{
    class Killer
    {
        public static string procName = null;
        public static int intIntervalMinute = 0;
        public static int intIntervalLive = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Please input procName below:");
            procName = Console.ReadLine().ToString();

            Console.WriteLine("Please input intIntervalMinute below:");
            intIntervalMinute = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input intIntervalLive below:");
            intIntervalLive = int.Parse(Console.ReadLine());

            killProcess(procName, intIntervalMinute, intIntervalLive);
        }

        private static void killProcess(string _procName,int _intIntervalMinute,int _intIntervalLive)
        {
            intIntervalMinute = _intIntervalMinute * 60;

            while (true)
            {
                Process[] runningNow = Process.GetProcesses();

                foreach (Process process in runningNow)
                {
                    if (process.ProcessName.Equals(_procName))
                    {
                        try
                        {
                            if (process.TotalProcessorTime.TotalMinutes > _intIntervalLive)
                            {
                                Console.WriteLine(string.Format("Killing {0} at {1}", _procName, DateTime.Now.ToString()));
                                process.Kill();
                            }
                        }
                       catch(Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Now running {0} at {1}", _procName, DateTime.Now.ToString()));
                    }
                }

                Thread.Sleep(intIntervalMinute);
            }

        }
    }
}
