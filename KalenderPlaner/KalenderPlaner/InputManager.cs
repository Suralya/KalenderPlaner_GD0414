using System;
using System.IO;
using System.Collections.Generic;


namespace KalenderPlaner
{
    /// <summary>
    /// The Input-Manager converts a File-Content into a string.
    /// </summary>
    static class InputManager
    {
        public static string FilePath;
        public static string Data;

        /// <summary>
        /// Pareses the File-Content and stores its value into a string-variable.
        /// </summary>
        /// <param name="args">
        /// The Files name. The files path must be similar to the programs path.
        /// </param> 
        /// <returns>
        /// Returns true if parsing was successful; returns false if some error appeared and writes an error-massage on the console.
        /// </returns> 
        public static bool Parse(string args)
        {

                try
                {
                    FilePath = Path.GetFullPath(args);
                    if (File.Exists(FilePath))
                    {
                        Data = File.ReadAllText(args);
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
