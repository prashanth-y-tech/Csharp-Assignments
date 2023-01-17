using System;




namespace CurrencyExchangeApp
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("No arguments found to Convert");
                    return;
                }
                if (args[0].Length > 3)
                {
                    Console.WriteLine($"Invalid Currency [{args[0]}]");
                    return;
                }
                if (args[1].Length > 3)
                {
                    Console.WriteLine($"Invalid Currency [{args[1]}]");
                    return;
                }
                try
                {
               
                    Console.WriteLine(CurrencyExchange.CurrencyConverter.ConvertCurrency(args[0], args[1], Convert.ToDouble(args[2])));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid input!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }


