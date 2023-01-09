using System;
using System.Linq;
using CurrencyExchange;


namespace CurrencyExchangeApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {

                if (args[0].Count<char>() > 3 || args[1].Count<char>() > 3)
                {
                    Console.WriteLine("Enter a valid Currency[Ex : USD, INR , AUD]");
                }
                else
                {
                    string toCurrency ;
                    string fromCurrency;
                    double Currencyvalue;
          
                    try
                    {
                        fromCurrency = args[0];
                        toCurrency = args[1];
                        Currencyvalue = Convert.ToDouble(args[2]);
                        Console.WriteLine($"{toCurrency} {Currencyvalue} is equavalent to {fromCurrency} {CurrencyConverter.Convert(fromCurrency, toCurrency, Currencyvalue)}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter a valid input!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            else
            {
                Console.WriteLine("No arguments found to Convert");
            }
        }
    }
}



