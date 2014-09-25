using L01._3.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int Count = 0;
            int[] arr;

            do
            {
                Count = ReadInt(Strings.Salary_Prompt);
                arr = ReadSalaries(Count);
                ViewResult(arr);
            }
            while (IsContinuing());
        }

        static bool IsContinuing()
        {
            ViewMessage(Strings.Continue_Prompt);

            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.WriteLine();

            return cki.Key != ConsoleKey.Escape;
        }

        static int ReadInt(string prompt)
        {
            int Count = 0;

            while (true)
            {
                Console.Write(prompt);

                Console.ForegroundColor = ConsoleColor.White;
                string str = Console.ReadLine();
                Console.ResetColor();

                try
                {
                    Count = int.Parse(str);
                    if (prompt == Strings.Salary_Prompt && Count < 2)
                    {
                        Console.WriteLine();
                        ViewMessage(Strings.TwoSalaries, ConsoleColor.Red);
                        Console.WriteLine();
                    }
                    else if (prompt != Strings.Salary_Prompt && Count <= 0)
                    {
                        Console.WriteLine();
                        ViewMessage(Strings.ErrorNegativOrZero, ConsoleColor.Red);
                        Console.WriteLine();
                    }
                    else
                    { 
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    ViewMessage(String.Format(Strings.Error_Message, str), ConsoleColor.Red);
                    Console.WriteLine();
                }
            }
            return Count;
        }

        static int[] ReadSalaries(int Count)
        {
            Console.WriteLine();

            int[] arr = new int[Count];
            for (int i = 0; i < Count; i++)
            {
                arr[i] = ReadInt(String.Format(Strings.SalaryNumber, i + 1));
            }
            return arr;
        }

        static void ViewMessage(string message, ConsoleColor backgroundColor = ConsoleColor.Blue, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void ViewResult(int[] salaries)
        {
            Console.WriteLine();
            ViewMessage(Strings.Filler, ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format(Strings.Median, MyExtension.Median(salaries)), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format(Strings.Medel, salaries.Average()), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format(Strings.Dispersion, MyExtension.Dispersion(salaries)), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(Strings.Filler, ConsoleColor.Black, ConsoleColor.Gray);
            Console.WriteLine();

            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write(Strings.Number, salaries[i]);

                if ((i + 1) % 3 == 0 && i!=salaries.Length-1)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }   
}

