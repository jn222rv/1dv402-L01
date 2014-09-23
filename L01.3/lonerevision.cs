using lonerevision.Properties;
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

            if (cki.Key == ConsoleKey.Escape)
            {
                return false;
            }
            else
            {
                return true;
            }
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
            ViewMessage("\n------------------------", ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format("Medianen:        {0,5:N0} kr", MyExtension.Median(salaries)), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format("Medellönen:      {0,5:N0} kr", salaries.Average()), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage(String.Format("Lösespridning:   {0,5:N0} kr", MyExtension.Dispersion(salaries)), ConsoleColor.Black, ConsoleColor.Gray);
            ViewMessage("------------------------\n", ConsoleColor.Black, ConsoleColor.Gray);

            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write("{0,7}", salaries[i]);

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

