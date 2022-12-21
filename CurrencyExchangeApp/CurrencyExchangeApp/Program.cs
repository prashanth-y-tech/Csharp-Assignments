using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter;
using RestSharp;
using System.Runtime.Serialization;

namespace CurrencyExchangeApp
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string to ="" ;
            string from="";
            double val=0;
            ConvertCurrency x = new ConvertCurrency();
            try {
                Console.WriteLine("Enter the currency you want to convert from :");
                 from = Console.ReadLine();
                Console.WriteLine("Enter the currency you want to convert into :");
                 to = Console.ReadLine();
                Console.WriteLine(String.Format("Enter the amount of {0} you want to convert :", to));
                 val = Convert.ToDouble(Console.ReadLine());
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Enter a valid input!");
                return 0;
            }
           
            if(to.Count() > 3 || from.Count() > 3) {
                Console.WriteLine("Enter a valid Currency[Ex : USD, INR]");
                return 0;
            }
            try
            {
                Console.WriteLine(String.Format("{0} {1} is equavalent to {2} {3}", from, val, to, x.Convert(to, from, val)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
            return 1;



        }
    }
}


