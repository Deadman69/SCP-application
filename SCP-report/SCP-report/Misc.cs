using System;
using System.Collections.Generic;
using System.Text;

namespace SCP_report
{
    class Misc
    {
        public static void displayColoredMessage(string message, ConsoleColor color) {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = previousColor;
        } 
    }
}
