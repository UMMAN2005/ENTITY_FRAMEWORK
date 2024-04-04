using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extensions {
    public static class SpecialPrints {

        public static void ColorPrint(string? text = null, ConsoleColor color = ConsoleColor.White) {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ColorPrintLine(string? text = "\n", ConsoleColor color = ConsoleColor.White) {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintStart(string? text) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(2000);
            PrintSlowly(text);
            Console.ResetColor();
        }

        private static void PrintSlowly(string? text, byte speed = 3) {
            for (int i = 0; i < text?.Length; i += speed) {
                int endIndex = Math.Min(i + speed, text.Length);
                Console.Write(text.Substring(i, endIndex - i));
                Thread.Sleep(1);
            }
            Console.WriteLine();
        }
    }
}
