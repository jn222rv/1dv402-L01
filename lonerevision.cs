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

                Count = ReadInt("Skriv in hur många löner det är: ");
                arr = ReadSalaries(Count);
                ViewResult(arr);

            }
            while (IsContinuing());
        }

        static bool IsContinuing()
        {
            ViewMessage("\n Tryck tangent för ny beräkning - Esc Avslutar \n");

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

        static int ReadInt(string prompt)
        {
            int Count = 0;

            while (true)
            {
                Console.Write(prompt);
                string str = Console.ReadLine();

                try  // NOT PRETTY
                {
                    Count = int.Parse(str);
                    if (prompt[0] == 'S' && Count < 2)
                    {
                        ViewMessage("\nDu måste ha minst 2 löner för att kunna göra en uträkning! \n", ConsoleColor.Red);
                    }
                    else
                        break;
                }
                catch
                {
                    ViewMessage(String.Format("\n'{0}' kan inte tolkas som ett värde! Testa igen.\n", str), ConsoleColor.Red);
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
                arr[i] = ReadInt(String.Format("Ange lön {0}: ", i + 1));
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
            ViewMessage("\n----------------", ConsoleColor.Black);
            ViewMessage(String.Format("Medianen: {0}", MyExtension.Median(salaries)), ConsoleColor.Black);
            ViewMessage(String.Format("Medellönen: {0:f2}", salaries.Average()), ConsoleColor.Black);
            ViewMessage(String.Format("Lösespridning: {0}", MyExtension.Dispersion(salaries)), ConsoleColor.Black);
            ViewMessage("----------------\n", ConsoleColor.Black);

            int number = ((salaries.Length - (salaries.Length % 3)) / 3) + 1;

            for (int i = 0; i < salaries.Length; i++)  // NOT PRETTY
            {
                Console.Write("{0,7}   ", salaries[i]);

                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
    static class MyExtension
    {
        public static int Dispersion(this int[] source)
        {
            int[] arr = source.OrderBy(a => a).ToArray();

            int number = arr.Max() - arr.Min();

            return number;
        }
        public static int Median(this int[] source)
        {
            int[] arr = source.OrderBy(a => a).ToArray();

            int number = arr.Length % 2;

            if (number == 0)  // NOT PRETTY
            {
                return (int)Math.Round(((arr[arr.Length / 2] + arr[(arr.Length / 2) - 1]) / (double)2));
            }
            else
            {
                return arr[(int)Math.Floor(arr.Length / (double)2)];
            }
        }
    }
}

