/* 
    github.com/L1ghtM4n/TorProxy
*/

using System;

namespace TorHandler.Utils
{
    internal sealed class Print
    {
        public static void Info(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[?] {0}", text);
            Console.ResetColor();
        }

        public static void Result(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
