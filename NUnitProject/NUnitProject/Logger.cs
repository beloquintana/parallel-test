using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject
{
    public class Logger
    {
        private static string Filepath = "";
        private static Logger _instance = null;
        private static readonly object padlock = new object();

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }

                return _instance;
            }
        }

        private Logger()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Filepath = Path.Combine(assemblyFolder, "log.txt");

            using (var log = File.CreateText(Filepath))
            {
                log.WriteLine($"Starting timestamp: {DateTime.Now.ToLocalTime()}");
            }
        }

        public void Info(string message)
        {
            WriteLine($"[INFO]: {message}");
        }

        public void Step(string message)
        {
            WriteLine($"    [STEP]: {message}");
        }

        public void Warning(string message)
        {
            WriteLine($"[WARNING]: {message}");
        }

        public void Error(string message)
        {
            WriteLine($"[ERROR]: {message}");
        }

        public void Fatal(string message)
        {
            WriteLine($"[FATAL]: {message}");
        }

        private void WriteLine(string text)
        {
            lock (padlock)
            {
                using (var log = File.AppendText(Filepath))
                {
                    log.WriteLine(text);
                }
            }            
        }

        private void Write(string text)
        {
            lock (padlock)
            {
                using (var log = File.AppendText(Filepath))
                {
                    log.Write(text);
                }
            }
        }
    }
}
