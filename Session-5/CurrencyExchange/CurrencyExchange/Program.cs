using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using CurrencyConverter;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities.Collections;
using Newtonsoft.Json;

namespace CurrencyExchangeApp
{
    internal class Program
    {
        static void Main(string[] args)
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
                        Console.WriteLine(string.Format("{0} {1} is equavalent to {2} {3}", (object)fromCurrency, (object)Currencyvalue, (object)toCurrency, CurrencyConverter.CurrencyConverter.ConvertCurrency(fromCurrency, toCurrency, Currencyvalue)));
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




