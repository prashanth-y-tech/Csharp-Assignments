﻿using CurrencyExchange;
using System;
using System.Linq;

namespace CurrencyExchangeApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Count() > 0)
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
                        Console.WriteLine(string.Format("{0} {1} is equavalent to {2} {3}", (object)fromCurrency, (object)Currencyvalue, (object)toCurrency, CurrencyConverter.Convert(fromCurrency, toCurrency, Currencyvalue)));
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
