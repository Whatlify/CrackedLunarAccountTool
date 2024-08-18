using System;
using System.Drawing;
using Console = Colorful.Console;

namespace CrackedLunarAccountTool.Helpers
{
    internal class ConsoleHelpers
    {
        public static void Print(string info, string text, Color color)
        {
            var dateDebug = DateTime.Now.ToString("HH:mm:ss");

            Console.Write($@" [{dateDebug}] > ", Color.FromArgb(80, 80, 80));
            Console.Write($@"[{info}] ", color);
            Console.Write(text);
        }

        public static void PrintLine(string info, string text, Color color)
        {
            var dateDebug = DateTime.Now.ToString("HH:mm:ss");

            Console.Write($@" [{dateDebug}] > ", Color.FromArgb(80, 80, 80));
            Console.Write($@"[{info}] ", color);
            Console.Write($@"{text}{Environment.NewLine}");
        }
    }
}