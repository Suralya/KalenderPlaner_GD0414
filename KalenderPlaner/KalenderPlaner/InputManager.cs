using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalenderPlaner
{
    static class InputManager
    {
        public static string FilePath;
        public static string Data;

        public static bool Parse(string[] args)
        {
            if (args.Length == 1)
            {
                try
                {
                    FilePath = Path.GetFullPath(args[0]);
                    if (File.Exists(FilePath))
                    {
                        Data = File.ReadAllText(args[0]);
                        return true;
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (FileNotFoundException e)
                {
                    WriteError("Kein gültiges Dokument gefunden.");
                } 
                catch (Exception e)
                {
                    WriteError("Ausnahme aufgetreten: " + e.Message);
                } 
            }
            return false;
        }

        private static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + message + Environment.NewLine);
            Console.ForegroundColor = Program.DefaultColor;
        }
    }
}
