using System;
using System.Diagnostics;

namespace uuUtils
{
    public class Log
    {
        public Log()
        {
        }

        public static void Console(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }

        public static void Debug(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}

