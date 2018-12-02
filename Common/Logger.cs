using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logger
    {
        private static object _key = new object();
        private static Logger _logInstance { get; set; }
        public static Logger Log
        {
            get
            {
                lock (_key)
                {
                    if (_logInstance == null)
                        _logInstance = new Logger();
                    return _logInstance;
                }
            }
        }

        private Logger() { }
        
        public void WriteToLog(string msg)
        {
            File.AppendAllText("logger.txt", msg + Environment.NewLine);
        }   
    }
}
