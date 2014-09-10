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
            uint[] denominations;
            
            ConsoleKeyInfo cki;

            do
            {
                subtotal = ReadPositiveDouble("Skriv en positiv double: ");
                cash = (uint)ReadUint("Skriv anållet belopp: ", (uint)Math.Round(subtotal));

                roundingOffAmount = (int)Math.Round(subtotal);
                change = cash - (uint)Math.Round(subtotal);
                total = (uint)Math.Round(subtotal);

                denominations = SplitIntoDenominations((uint)change, notes);

                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                ViewMessage("Tryck tangent för mer, annar Esc");
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        static uint TestMethod(uint test, uint bills)
        {
            uint returnValue;

            //Divide by Zero Error - unsolved
            uint rest = test % bills;

            if (rest == 0)
            {
                returnValue = test / bills;
            }
            else
            {
                returnValue = (test - rest)/bills;
            }

            return returnValue;
        } 
        
        static double ReadPositiveDouble(string prompt)
        {
            double value = 3.0;
            
            while(true)
            {
                Console.Write(prompt);
                string str = Console.ReadLine();
                try
                {
                    value = double.Parse(str);
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        if (value >= 1)
                        {
                            return value;
                        }
                        else
                        {
                            ViewMessage("Läs instruktionerna, välj nytt nummer: ", true);
                            Console.WriteLine();
                        }                    
                    }
                }
                catch
                {
                    ViewMessage("FEL! '", true);
                    ViewMessage(str, true);
                    ViewMessage("' kan inte tolkas som giltig summa pengar!", true);
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
                    ViewMessage("FEL! '", true);
                    ViewMessage(str, true);
                    ViewMessage("' kan inte tolkas som giltig summa pengar!", true);
                    Console.WriteLine();
                }
            }
        }
        static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            for (int i = 0; i < denominations.Length; i++)
            {
                uint times = denominations[i];
                denominations[i] = TestMethod(change, denominations[i]);
                change -= denominations[i] * times;
            }

                return denominations;
        }
        static void ViewMessage(string message, bool isError = false)
        {
            if(isError)
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

            if (notes[0] > 0)
            {
                Console.WriteLine("500-lappar: {0}", notes[0]);            
            }
            if (notes[1] > 0)
            {
                Console.WriteLine("100-lappar: {0}", notes[1]);            
            }
            if (notes[2] > 0)
            {
                Console.WriteLine("50-lappar: {0}", notes[2]);
            } 
            if (notes[3] > 0)
            {
                Console.WriteLine("20-lappar: {0}", notes[3]);
            }
            if (notes[4] > 0)
            {
                Console.WriteLine("10-kronor: {0}", notes[4]);
            } 
            if (notes[5] > 0)
            {
                Console.WriteLine("5-kronor: {0}", notes[5]);
            }
            if (notes[6] > 0)
            {
                Console.WriteLine("1-kronor: {0}", notes[6]);
            }
            Console.WriteLine("");         
        }
    }       
}
