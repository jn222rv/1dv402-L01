using L01.Properties;
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
            uint[] denominations;
            
            ConsoleKeyInfo cki;

            do
            {
                subtotal = ReadPositiveDouble(Strings.SubTotal_Prompt);
                cash = ReadUint(Strings.Cash_Prompt, (uint)Math.Round(subtotal));

                roundingOffAmount = (int)Math.Round(subtotal);
                change = cash - (uint)Math.Round(subtotal);
                total = (uint)Math.Round(subtotal);

                denominations = SplitIntoDenominations((uint)change, notes);

                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                ViewMessage(Strings.Continue_Prompt);
                cki = Console.ReadKey(true); 
                Console.WriteLine();
            }
            while (cki.Key != ConsoleKey.Escape);
        }        
        static double ReadPositiveDouble(string prompt)
        {
            string str;
            double value;

            while (true)
            {
                Console.Write(prompt);
                str = Console.ReadLine();
                try
                {
                    value = double.Parse(str);
                    
                    if (value >= 1)
                    {
                        return value;
                    }
                    else if (value < 0)
                    {
                        Console.WriteLine();
                        ViewMessage(Strings.PositivDouble,true);
                        Console.WriteLine();
                    }
                    else
                    {                       
                        Console.WriteLine();
                        ViewMessage(Strings.AtleastOne, true);
                        Console.WriteLine();
                    }
                }
                catch
                {
                    Console.WriteLine();
                    ViewMessage(String.Format(Strings.Error_Message, str),true);
                    Console.WriteLine();
                }
            }
        }
        static uint ReadUint(string prompt, uint minValue)
        {
            string str;
            uint value;

            while (true)
            {
                Console.Write(prompt);
                str = Console.ReadLine();
                try
                {
                    value = uint.Parse(str);
                    if (value >= minValue)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine();
                        ViewMessage(String.Format(Strings.TooSmall,value), true);
                        Console.WriteLine();
                    }
                }
                catch
                {
                    Console.WriteLine();
                    ViewMessage(String.Format(Strings.Error_Message,str),true);
                    Console.WriteLine();
                }
            }
        }
        static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            uint[] arr = new uint[denominations.Length];
            
            for (int i = 0; i < denominations.Length; i++)
            {
                arr[i] = NumberOfTimes(change, denominations[i]);
                change -= arr[i] * denominations[i];
            }

            return arr;
        }
        static uint NumberOfTimes(uint total, uint note)
        {
            uint numberOfTimes;

            uint rest = total % note;

            if (rest == 0)
            {
                numberOfTimes = total / note;
            }
            else
            {
                numberOfTimes = (total - rest) / note;
            }

            return numberOfTimes;
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
            Console.WriteLine();
        }
    }
}
