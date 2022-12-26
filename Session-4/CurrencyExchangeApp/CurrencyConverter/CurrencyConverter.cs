using Newtonsoft.Json;
using System;
using RestSharp;
using System.Collections.Generic;
using System.IO;


namespace CurrencyConverter
{
    public class CurrencyExchange
    {
        public void GetApidata()
        {
            try {
                RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
                RestRequest request = new RestRequest();
                request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
                apiResponse.quotes.Add("timestamp", apiResponse.timestamp);
                File.WriteAllText("C:\\Users\\prashanth yarram\\OneDrive\\Desktop\\sample.txt", JsonConvert.SerializeObject((object)apiResponse.quotes));
            }
            catch(Exception e) {
                throw e.InnerException;
            }
                
        }

        public double Convert(string fromCurrency, string toCurrency, double Currencyvalue)
        {
            CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]");
            if (toCurrency == fromCurrency)
                return 1.0;
            string key = fromCurrency + toCurrency;
            if (File.Exists("C:\\Users\\prashanth yarram\\OneDrive\\Desktop\\sample.txt"))
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)(int)JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText("C:\\Users\\prashanth yarram\\OneDrive\\Desktop\\sample.txt"))["timestamp"]);
                dateTime = dateTime.ToLocalTime().Date;
                string str1 = dateTime.ToString("M/d/yyyy");
                dateTime = DateTime.Now;
                string str2 = dateTime.ToString("M/d/yyyy");
                if (str1 != str2)
                    this.GetApidata();
            }
            else
                this.GetApidata();
            Dictionary<string, double> dictionary = JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText("C:\\Users\\prashanth yarram\\OneDrive\\Desktop\\sample.txt"));
            if (toCurrency == "INR")
            {
                if (dictionary.ContainsKey(toCurrency + fromCurrency))
                    return 1.0 / dictionary[toCurrency + fromCurrency] * Currencyvalue;
                throw notFoundException;
            }
            if (fromCurrency == "INR")
            {
                if (dictionary.ContainsKey(key))
                    return dictionary[key] * Currencyvalue;
                throw notFoundException;
            }
            if (dictionary.ContainsKey("INR" + fromCurrency) && dictionary.ContainsKey("INR" + fromCurrency))
                return dictionary["INR" + fromCurrency] / dictionary["INR" + toCurrency] * Currencyvalue;
            throw notFoundException;
        }
    }
}

