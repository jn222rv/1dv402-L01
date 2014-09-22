using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaxelpengar
{
    class Program
    {
        static void Main(string[] args)
        {
            uint cash, change, total;
            double subtotal, roundingOffAmount;

            uint[] notes = { 500, 100, 50, 20, 10, 5, 1 };
            uint[] denominations = { 500, 100, 50, 20, 10, 5, 1 };
            
            ConsoleKeyInfo cki;

            do
            {
                subtotal = ReadPositiveDouble("Ange totalsumman    : ");
                cash = ReadUint("Ange erhållet belopp: ", (uint)Math.Round(subtotal));

                roundingOffAmount = (int)Math.Round(subtotal);
                change = cash - (uint)Math.Round(subtotal);
                total = (uint)Math.Round(subtotal);

                for (int i = 0; i < notes.Length; i++)
                {
                    denominations[i] = notes[i];
                }

                SplitIntoDenominations((uint)change, denominations);

                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                ViewMessage("Tryck tangent för ny beräkning - Esc avslutar.");
                cki = Console.ReadKey(true); 
                Console.WriteLine();
            }
            while (cki.Key != ConsoleKey.Escape);
        }        
        static double ReadPositiveDouble(string prompt)
        {
            double value;
            string str;

            while (true)
            {
                Console.Write(prompt);
                str = Console.ReadLine();
                try
                {
                    value = double.Parse(str);
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        if (value >= 1)
                        {
                            return value;
                        }
                        else
                        {
                            ViewMessage("\nTalet måste vara minst 1, välj nytt nummer: ", true);
                            Console.WriteLine();
                        }
                    }
                }
                catch
                {
                    ViewMessage("\nFEL! '", str, "' kan inte tolkas som en giltig summa pengar.", true);
                    Console.WriteLine();
                }
            }
        }
        static uint ReadUint(string prompt, uint minValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string str = Console.ReadLine();
                try
                {
                    uint value = uint.Parse(str);
                    if (value >= minValue)
                    {
                        return value;
                    }
                    else
                    {
                        ViewMessage(String.Format("\nFEL! {0} är ett för litet belopp\n",value), true);
                    }
                }
                catch
                {
                    ViewMessage("\nFEL! '", str, "' kan inte tolkas som giltig summa pengar!\n",true);
                }
            }
        }
        static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            uint times;
            for (int i = 0; i < denominations.Length; i++)
            {
                times = denominations[i];
                denominations[i] = NumberOfTimes(change, denominations[i]);
                change -= denominations[i] * times;
            }

            return denominations;
        }
        static uint NumberOfTimes(uint total, uint note)
        {
            uint NumberOfTimes;

            uint rest = total % note;

            if (rest == 0)
            {
                NumberOfTimes = total / note;
            }
            else
            {
                NumberOfTimes = (total - rest) / note;
            }

            return NumberOfTimes;
        }
        static void ViewMessage(string message, bool isError = false)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        static void ViewMessage(string firstMessage,string secondMessage, string thirdMessage, bool isError = false)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(firstMessage);
                Console.Write(secondMessage);
                Console.WriteLine(thirdMessage);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(firstMessage);
                Console.Write(secondMessage);
                Console.WriteLine(thirdMessage);
                Console.ResetColor();
            }
        }

        static void ViewReceipt(double subtotal, double roundingOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)
        {
            Console.WriteLine("");
            Console.WriteLine("Kvitto");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total Summa är     :      {0,5} kr", subtotal);
            Console.WriteLine("Avrundingen blir   :      {0,5:f2} kr", roundingOffAmount - subtotal);
            Console.WriteLine("Att betala         :      {0,5} kr", roundingOffAmount);
            Console.WriteLine("Kontant            :      {0,5} kr", cash);
            Console.WriteLine("Tillbaka           :      {0,5} kr", change);
            Console.WriteLine("----------------------------------\n");

            for (int i = 0; i < denominations.Length; i++)
            {
                if (denominations[i] > 0)
                {
                    if (notes[i] >= 20)
                    {
                        Console.WriteLine("{0,3}-lappar: {1,3}", notes[i], denominations[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0,3}-kronor: {1,3}", notes[i], denominations[i]);
                    }
                }
            }
            Console.WriteLine("");
        }
    }
}
