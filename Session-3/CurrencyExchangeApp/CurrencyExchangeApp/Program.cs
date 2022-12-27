using System;
using System.Linq;
using CurrencyConverter;


namespace CurrencyExchangeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Count<char>() > 3 || args[1].Count<char>() > 3)
            {
                Console.WriteLine("Enter a valid Currency[Ex : USD, INR , AUD]");
            }
            else
            {
                string toCurrency = "";
                string fromCurrency = "";
                double Currencyvalue = 0.0;
                CurrencyExchange currencyExchange = new CurrencyExchange();
                try
                {
                    fromCurrency = args[0];
                    toCurrency = args[1];
                    Currencyvalue = Convert.ToDouble(args[2]);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a valid input!");
                }
                try
                {
                    Console.WriteLine($"{fromCurrency} {Currencyvalue} is equavalent to {toCurrency} {currencyExchange.Convert(fromCurrency, toCurrency, Currencyvalue)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}



