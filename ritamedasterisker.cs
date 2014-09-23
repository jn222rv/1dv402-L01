using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Collections;

namespace ritamedasterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            byte maxCount;
            const byte maxAst = 79;

            do
            {
                maxCount = ReadOddByte("Skriv Byte: ", maxAst);
                RenderDiamond(maxCount);
            }
            while (IsContinue());
        }
        static bool IsContinue()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("\nTryck tangent för att fortsätta - Esc avslutar");
            Console.ResetColor();

            ConsoleKeyInfo cki = Console.ReadKey(true);

            Console.WriteLine("\n");

            if (cki.Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static byte ReadOddByte(string prompt = null, byte maxCount = 255)
        {
            byte count;

            while(true)
            {
                Console.Write(prompt);
                string str = Console.ReadLine();
                try
                {
                    count = byte.Parse(str);
                    if (count > maxCount || count < 1 ||(count % 2) == 0)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        return count;
                    }
                }
                catch (ArgumentException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFEL! Det inmatade värdet är inte ett udda heltal mellan 1 och 79.\n");
                    Console.ResetColor();
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'{0}' kan inte tolkas som ett positivt Heltal\n", str);
                    Console.ResetColor();
                }
            }
        }
        static void RenderDiamond(byte maxCount)
        {
            Console.WriteLine();
           
            int astcount = 0;

            for (int i = 0; i < maxCount; i++)
            {
                if (i == 0)
                {
                    astcount = 1; 
                }  
                else if ((i * 2) + 1 <= maxCount)
                {
                    astcount += 2;
                }
                else
                {
                    astcount -= 2;
                }
                RenderRow(maxCount, astcount);
            }
        }
        static void RenderRow(int maxCount, int asteriskCount)
        {
            int minInterval = (maxCount - asteriskCount) / 2;
            int maxInterval = (maxCount - minInterval) - 1;

            for (int i = 0; i < maxCount; i++)
            {
                if (i < minInterval || i > maxInterval)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine("");
        }
    }
}
