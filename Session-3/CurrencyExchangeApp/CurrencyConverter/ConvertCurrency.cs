using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;


namespace CurrencyConverter
{
    public class ConvertCurrency
    {
        public dynamic Convert(string from, string to, double value)
        {
            string currency = String.Format("{0}{1}", to, from);
            var client = new RestClient(String.Format("https://api.apilayer.com/currency_data/live?source={0}&currencies={1}", to, from));
            var request = new RestRequest();
            request.AddHeader("apikey", "QHbQjcYfLJzxGT3UAFEu2KcQW4GAQWcg");
            CurrencyObject ApiObject=new CurrencyObject();
            RestResponse response = client.Get(request);
            ApiObject = JsonConvert.DeserializeObject<CurrencyObject>(response.Content);
            if (ApiObject.success==true)
            {
                if(to == from)
                {
                    Exception SameCurrencyException = new Exception("Enter different currencies to convert");
                    throw SameCurrencyException;
                    return 1;
                }
                double curr_val = ApiObject.quotes[currency];
                return curr_val * value;
            }
            else if (ApiObject.success == false)
            {
                Exception CurrrencyNotFound = new Exception("Enter a valid Currency[Ex : USD, INR]");
                throw CurrrencyNotFound;
            }
            return 0.00;

            
        }
    }
}
