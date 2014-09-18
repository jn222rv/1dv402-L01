using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ritamedasterisker
{
    class Program
    {
        static void Main(string[] args)
        {
            byte maxCount;
            byte number = 7;

            do
            {
                maxCount = ReadOddByte("Skriv Byte: ", number = 7);

                RenderDiamond(maxCount);
            }
            while (IsContinue());
        }
        static bool IsContinue()
        {
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static byte ReadOddByte(string prompt, byte count)
        {
            Console.Write(prompt);
            count = byte.Parse(Console.ReadLine());

            return count;
        }
        static void RenderDiamond(byte maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                int newMax = maxCount;
                int astcount;

                if ((i * 2) + 1 <= newMax)
                {
                    astcount = (i * 2) + 1;
                }
                else
                {
                    astcount = ((maxCount - i) - 1) * 2 + 1;
                }

                RenderRow(newMax, astcount);
            }
        }
        static void RenderRow(int maxCount, int asteriskCount)
        {
            int testNumber = (maxCount - asteriskCount) / 2;
            for (int i = 0; i < maxCount; i++)
            {
                if (i < testNumber || i >= maxCount - testNumber)
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
