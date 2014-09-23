using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Collections;
using L01._2.Properties;

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
                maxCount = ReadOddByte(Strings.Starting_Message, maxAst);
                RenderDiamond(maxCount);
            }
            while (IsContinue());
        }
        static bool IsContinue()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write(Strings.Continue_Prompt);
            Console.ResetColor();

            ConsoleKeyInfo cki = Console.ReadKey(true);

            Console.WriteLine();
            Console.WriteLine();

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
                    if (count > maxCount || (count % 2) == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine(Strings.Byte_Error);
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        return count;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine(String.Format(Strings.Error_Message,str));
                    Console.WriteLine();
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
            Console.WriteLine();
        }
    }
}
