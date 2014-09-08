using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L02C
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = Properties.Resources.Console_Title;
            const int MaxValue = 79;
            do
            {
                Console.Write(String.Format(Properties.Resources.Ask_Asterisk, MaxValue));
                byte asterisks = ReadOddByte(Console.ReadLine(), MaxValue);
                RenderDiamond(asterisks);
            } while (IsContinuing());
        }

        private static bool IsContinuing()
        {
            Console.WriteLine();
            ViewMessage(Properties.Resources.Continue_Prompt);
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }

        private static void ViewMessage(string message, bool isError = false)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (!isError)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(message);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            while (true)
            {
                if (prompt == null)
                {
                    Console.Write(String.Format(Properties.Resources.Ask_Asterisk, maxValue));
                    prompt = Console.ReadLine();
                }
                try
                {
                    if (byte.Parse(prompt) % 2 == 0 || byte.Parse(prompt) < 1 || int.Parse(prompt) > maxValue)
                    {
                        throw new Exception();
                    }
                    return byte.Parse(prompt);
                }
                catch
                {
                    ViewMessage(String.Format(Properties.Resources.Error_Message, prompt, maxValue), true);
                    prompt = null;
                }
            }
        }

        private static void RenderDiamond(byte maxCount)
        {
            int asteriskCount;
            if (maxCount > 1)
            {
                for (asteriskCount = 1; asteriskCount < maxCount; asteriskCount += 2)
                {
                    RenderRow(maxCount, asteriskCount);
                }
                for (asteriskCount = maxCount; asteriskCount >= 1; asteriskCount -= 2)
                {
                    RenderRow(maxCount, asteriskCount);
                }
            }
            else
            {
                RenderRow(maxCount, 1);
            }
        }

        private static void RenderRow(int maxCount, int asteriskCount)
        {
            Console.WriteLine();
            for (int rowPosition = 0; rowPosition < maxCount; rowPosition++)
            {
                if (maxCount == asteriskCount ||
                    rowPosition >= maxCount / 2 - asteriskCount / 2 &&
                    rowPosition <= maxCount / 2 + asteriskCount / 2)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
