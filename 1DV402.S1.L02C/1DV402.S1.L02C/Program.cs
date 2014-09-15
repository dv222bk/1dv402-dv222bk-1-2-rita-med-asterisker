using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L02C
{
    class Program
    {
        /// <summary>
        /// The core of the program.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        private static void Main(string[] args)
        {
            Console.Title = Properties.Resources.Console_Title;
            const int MaxValue = 79; // the maximum number of asterisks printed
            do
            {
                byte asterisks = ReadOddByte(String.Format(Properties.Resources.Ask_Asterisk, MaxValue), MaxValue);
                RenderDiamond(asterisks);
            } while (IsContinuing());
        }

        /// <summary>
        /// Asks the user if the program should continue to run.
        /// </summary>
        /// <returns>Retúrns true if the program should continue to run, false if it shouldn't</returns>
        private static bool IsContinuing()
        {
            Console.Write("\n");
            ViewMessage(Properties.Resources.Continue_Prompt);
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Shows a message to the user with a colored background
        /// </summary>
        /// <param name="message">The message that should be shown to the user</param>
        /// <param name="isError">Is this an error message? true = red background, false = darkgreen background</param>
        private static void ViewMessage(string message, bool isError = false)
        {
            Console.Write("\n");
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
            Console.Write("\n");
        }

        /// <summary>
        /// Asks the user for an odd byte within a specific range of byte values.
        /// Will continue to ask the user for a byte until a correct value is submited
        /// </summary>
        /// <param name="prompt">The prompt sent to the user. Default is null</param>
        /// <param name="maxValue">Max byte value the user is permitted to enter. Default is 255</param>
        /// <returns>Returns the odd byte value entered by the user</returns>
        private static byte ReadOddByte(string prompt = null, byte maxValue = 255)
        {
            string answer;
            while (true)
            {
                Console.Write(prompt);
                answer = Console.ReadLine();
                try
                {
                    if (byte.Parse(answer) % 2 == 0 || byte.Parse(answer) < 1 || int.Parse(answer) > maxValue)
                    {
                        throw new Exception();
                    }
                    return byte.Parse(answer);
                }
                catch
                {
                    ViewMessage(String.Format(Properties.Resources.Error_Message, answer, maxValue), true);
                }
            }
        }

        /// <summary>
        /// Renders a diamond of asterisks.
        /// </summary>
        /// <param name="maxCount">The maximum amount of asterisks on a single line</param>
        private static void RenderDiamond(byte maxCount)
        {
            int asteriskCount;
            if (maxCount > 1)
            {
                for (asteriskCount = 1; asteriskCount < maxCount; asteriskCount += 2) //since it's an odd number of asterisks on each row, two needs to be added each time
                {
                    RenderRow(maxCount, asteriskCount);
                }
                for (asteriskCount = maxCount; asteriskCount >= 1; asteriskCount -= 2) //same here but in reverse
                {
                    RenderRow(maxCount, asteriskCount);
                }
            }
            else
            {
                RenderRow(maxCount, 1);
            }
        }

        /// <summary>
        /// Renders a row (of specific length) of asterisks. The asterisks will occupy the middle of the row.
        /// </summary>
        /// <param name="maxCount">The maximum number of character spaces on the line</param>
        /// <param name="asteriskCount">The number of asterisks on the line</param>
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
