using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1_vaxelpengar
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
                subtotal = ReadPositiveDouble("Skriv en positiv double: ");
                cash = (uint)ReadUint("Skriv anållet belopp: ", (uint)Math.Round(subtotal));

                roundingOffAmount = (int)Math.Round(subtotal);
                change = cash - (uint)Math.Round(subtotal);
                total = (uint)Math.Round(subtotal);

                for (int i = 0; i < notes.Length; i++)
                {
                    denominations[i] = notes[i];
                }

                SplitIntoDenominations((uint)change, denominations);

                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                ViewMessage("Tryck tangent för mer, annar Esc");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
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

        static double ReadPositiveDouble(string prompt)
        {
            double value;

            while (true)
            {
                Console.Write(prompt);
                string str = Console.ReadLine();
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
                            ViewMessage("Talet måste vara minst 1, välj nytt nummer: ", true);
                            Console.WriteLine();
                        }
                    }
                }
                catch
                {
                    ViewMessage("FEL! '", str, "' kan inte tolkas som giltig summa pengar!", true);
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
                        ViewMessage("Det var mindre än vad som krävs!", true);
                        Console.WriteLine();
                    }
                }
                catch
                {
                    ViewMessage("FEL! '", str, "' kan inte tolkas som giltig summa pengar!",true);
                    Console.WriteLine();
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
        static void ViewMessage(string message, bool isError = false)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(message);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(message);
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
                Console.Write(thirdMessage);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(firstMessage);
                Console.Write(secondMessage);
                Console.Write(thirdMessage);
                Console.ResetColor();
            }
        }

        static void ViewReceipt(double subtotal, double roundingOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)
        {
            Console.WriteLine("");
            Console.WriteLine("Kvitto");
            Console.WriteLine("**************************************");
            Console.WriteLine("Total Summa är: {0}", subtotal);
            Console.WriteLine("Avrundingen blir: {0:f2}", roundingOffAmount - subtotal);
            Console.WriteLine("Att betala: {0}", roundingOffAmount);
            Console.WriteLine("Kontant: {0}", cash);
            Console.WriteLine("Tillbaka: {0}", change);
            Console.WriteLine("**************************************");


            Console.WriteLine("");

            if (denominations[0] > 0)
            {
                Console.WriteLine("{0}-lappar: {1}", notes[0], denominations[0]);
            }
            if (denominations[1] > 0)
            {
                Console.WriteLine("{0}-lappar: {1}", notes[1], denominations[1]);
            }
            if (denominations[2] > 0)
            {
                Console.WriteLine("{0}-lappar: {1}", notes[2], denominations[2]);
            }
            if (denominations[3] > 0)
            {
                Console.WriteLine("{0}-lappar: {1}", notes[3], denominations[3]);
            }
            if (denominations[4] > 0)
            {
                Console.WriteLine("{0}-kronor: {1}", notes[4], denominations[4]);
            }
            if (denominations[5] > 0)
            {
                Console.WriteLine("{0}-kronor: {1}", notes[5], denominations[5]);
            }
            if (denominations[6] > 0)
            {
                Console.WriteLine("{0}-kronor: {1}", notes[6], denominations[6]);
            }
            Console.WriteLine("");
        }
    }
}
