using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_Mobile
{
    class Utility
    {
        public static void SplashScreen(string title, string name, double version)
        {
            Console.Title = title + " v." + version;
            TextColor(ConsoleColor.DarkCyan, "------\n--------\n-----------");
            TextColor(ConsoleColor.Cyan, "-------------\n---------------");
            TextColor(ConsoleColor.White, $" {title}");
            TextColor(ConsoleColor.White, $"\n Built by: {name}");
            TextColor(ConsoleColor.White, $"\n Version: {version}");
            TextColor(ConsoleColor.Cyan, "---------------\n-------------");
            TextColor(ConsoleColor.DarkCyan, "-----------\n--------\n------\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.Beep(700, 50);
            Console.Beep(550, 50);
            Console.Beep(725, 50);
            Console.Beep(400, 250);
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        }
        public static void Bloop()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            System.Threading.Thread.Sleep(125); Console.Beep(659, 125);
            System.Threading.Thread.Sleep(167); Console.Beep(523, 125);
            Console.Beep(659, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(784, 125); System.Threading.Thread.Sleep(375);
            Console.Beep(392, 125); System.Threading.Thread.Sleep(375);
            Console.Beep(523, 125); System.Threading.Thread.Sleep(250);
            Console.Beep(392, 125); System.Threading.Thread.Sleep(250);
            Console.Beep(330, 125); System.Threading.Thread.Sleep(250);
            Console.Beep(440, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(494, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(466, 125); System.Threading.Thread.Sleep(42);
            Console.Beep(440, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(392, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(659, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(784, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(880, 125); System.Threading.Thread.Sleep(125);
            Console.Beep(698, 125); Console.Beep(784, 125);
            System.Threading.Thread.Sleep(125); Console.Beep(659, 125);
            System.Threading.Thread.Sleep(125);
        }
        public static void TextColor(ConsoleColor color, string prompt, bool writeLine = true)
        {
            Console.ForegroundColor = color;
            string select = writeLine ? prompt + "\n" : prompt;
            Console.Write(select);
            Console.ResetColor();
        }
        public static int MenuBuild(string title, string[] selections)
        {
            Console.Clear();
            TextColor(ConsoleColor.Cyan, $"\n* * * {title} * * *\n");
            for (int index = 0; index < selections.Length; index++)
            {
                TextColor(ConsoleColor.White, $"  {index + 1}. {selections[index]}");
            }
            return ValidateNum(1, selections.Length);
        }
        public static int ValidateNum(int min, int max) // Requires 1. Minimum Choice & 2. Maximum Choice
        {

            while (true)
            {
                TextColor(ConsoleColor.Cyan, "\nEnter Selection: ", false);
                if (int.TryParse(Console.ReadLine(), out int output) && output >= min && output <= max)
                {
                    Console.Beep(800, 100);
                    return output;
                }
                else { InputError(); }
            }
        }
        public static void InputError() // RED "[Input Error -- Please Try Again]"
        {
            TextColor(ConsoleColor.Red, "[Input Error -- Please Try Again]");
            Console.Beep(300, 200);
        }
        public static void ExitProgram() //GREEN "Goodbye!"
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            TextColor(ConsoleColor.DarkCyan, "------\n--------\n-----------");
            TextColor(ConsoleColor.Cyan, "-------------\n---------------");
            TextColor(ConsoleColor.White, " Thank you for using the Program!\n\t\t\t\t-Decker A.");
            TextColor(ConsoleColor.Cyan, "---------------\n-------------");
            TextColor(ConsoleColor.DarkCyan, "-----------\n--------\n------\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            ExitSong();
            System.Threading.Thread.Sleep(400);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            Environment.Exit(0);
        }
        public static void ExitSong()
        {
            Console.Beep(200, 100);
            Console.Beep(300, 100);
            Console.Beep(400, 100);
            Console.Beep(300, 100);
            Console.Beep(200, 100);
            Console.Beep(300, 100);
            Console.Beep(300, 100);
            Console.Beep(200, 100);
            Console.Beep(300, 100);
            Console.Beep(100, 500);
        }
        public static void ReturnMenu()
        {
            Utility.TextColor(ConsoleColor.Green, "\n-- Returning to Main Menu --\n");
        }
        public static string GatherString(string prompt) // Requires prompt string - Returns collected string
        {
            TextColor(ConsoleColor.Cyan, prompt, false);
            return Console.ReadLine();
        }
        public static int GatherInt(string prompt) // Requires prompt string - Returns collected string
        {
            TextColor(ConsoleColor.Cyan, prompt, false);
            return int.Parse(Console.ReadLine());
        }
        public static double GatherDouble(string prompt) // Requires prompt string - Returns collected string
        {
            TextColor(ConsoleColor.Cyan, prompt, false);
            return double.Parse(Console.ReadLine());
        }
        public static bool BoolCollect(string prompt) //Returns bool (used for a key) prompt without (Y/N) required
        {
            while (true)
            {
                string choice = GatherString("\n" + prompt + "(Y/N): ");
                if (choice.ToUpper() == "Y") { return true; }
                else if (choice.ToUpper() == "N") { return false; }
                else { InputError(); }
            }
        }
        public static DateTime GatherDate(string prompt)
        {
            while (true)
            {
                bool test = DateTime.TryParse(Utility.GatherString(prompt), out DateTime result);
                if (test) { return result; }
                else { InputError(); }
            }

        }
        public static void ProgramDetails(string title, string author, string description, double version)
        {
            TextColor(ConsoleColor.Green, $"\nTitle: {title}\nAuthor: {author}" +
                $"\nDescription: {description}\nVersion: {version}");
            Console.ReadLine();
        }

    }
}