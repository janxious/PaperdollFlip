﻿using System;
using System.IO;

namespace ArmorRepairDevTest
{
    class Logger
    {

        private static string path =>  $"{ArmorRepairDevTest.ModDirectory}/Log.txt";

        public Logger()
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                streamWriter.WriteLine("(NFO) " + DateTime.Now.ToString() + " - Logger started.");
            }
        }

        public static void LogError(Exception ex)
        {           
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine("(ERR) ");
                streamWriter.WriteLine(string.Concat(new string[]
                {
                    "Message :",
                    ex.Message,
                    Environment.NewLine,
                    "Stacktrace :",
                    ex.StackTrace
                }) + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                streamWriter.WriteLine(Environment.NewLine + "------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        public static void LogInfo(string line)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine("(NFO) " + DateTime.Now.ToString() + " - " + line);
            }
        }

        public static void LogDebug(string line)
        {
            if(ArmorRepairDevTest.ModSettings.Debug) { 
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine("(DBG) " + DateTime.Now.ToString() + " - " + line);
                }
            }
        }
    }
}

