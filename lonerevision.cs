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
                Count = ReadInt("Skriv in hur m�nga l�ner det �r: ");
                arr = ReadSalaries(Count);
                ViewResult(arr);

            }
            while (IsContinuing());
        }

        static bool IsContinuing()
        {
            ViewMessage("\n Tryck tangent f�r ny ber�kning - Esc Avslutar \n");

            ConsoleKeyInfo cki = Console.ReadKey(true);

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
                        ViewMessage("\nDu m�ste ha minst 2 l�ner f�r att kunna g�ra en utr�kning! \n", ConsoleColor.Red);
                    }
                    else
                        break;
                }
                catch
                {
                    ViewMessage(String.Format("\n'{0}' kan inte tolkas som ett v�rde! Testa igen.\n", str), ConsoleColor.Red);
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
                arr[i] = ReadInt(String.Format("Ange l�n {0}: ", i + 1));
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
            ViewMessage(String.Format("Medianen: {0:f0}", MyExtension.Median(salaries)), ConsoleColor.Black);
            ViewMessage(String.Format("Medell�nen: {0:f0}", salaries.Average()), ConsoleColor.Black);
            ViewMessage(String.Format("L�sespridning: {0:f0}", MyExtension.Dispersion(salaries)), ConsoleColor.Black);
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
}

