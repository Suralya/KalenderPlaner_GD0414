using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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


        public static RawInput Import(string jsonfile)
        {
            RawInput lists = JsonConvert.DeserializeObject<RawInput>(jsonfile);
            return lists;
        }

        public static List<Resource> ResourcesGet(RawInput lists)
        {
            return lists.Resources;
        }

        public static List<TimeConditions> UnavailableDatesGet(RawInput lists)
        {
            return lists.UnavailableDates;
        }

        public static List<Member> MembersGet(RawInput lists)
        {
            return lists.MemberList;
        }


        private static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + message + Environment.NewLine);
            Console.ForegroundColor = Program.DefaultColor;
        }
    }
}
