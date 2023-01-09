using Newtonsoft.Json;
using System;
using System.Configuration;
using RestSharp;
using System.Collections.Generic;
using System.IO;


namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        public static string filePath = (string)AppDomain.CurrentDomain.GetData("FilePath");
        private static ApiResponse GetApidata()
        {
            try {
                RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
                RestRequest request = new RestRequest();
                request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
                apiResponse.quotes.Add("timestamp", apiResponse.timestamp);
                return apiResponse;
                
            }
            catch(Exception e) {
                throw e.InnerException;
            }
                
        }


        public static double Convert(string fromCurrency, string toCurrency, double Currencyvalue)
        {
            
            if (toCurrency == fromCurrency)
                return 1.0;
            string key = fromCurrency + toCurrency;
            if (File.Exists(filePath))
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)(int)JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText(filePath))["timestamp"]);
                dateTime = dateTime.ToLocalTime().Date;
                string str1 = dateTime.ToString("M/d/yyyy");
                dateTime = DateTime.Now;
                string str2 = dateTime.ToString("M/d/yyyy");
                if (str1 != str2)
                    GetApidata();
            }
            else
            {
                ApiResponse apiResponse = GetApidata();
                File.WriteAllText(filePath, JsonConvert.SerializeObject((object)apiResponse.quotes));
            }

            Dictionary<string, double> dictionary = JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText(filePath));
            if (toCurrency == "INR")
            {
                if (dictionary.ContainsKey(toCurrency + fromCurrency))
                    return 1.0 / dictionary[toCurrency + fromCurrency] * Currencyvalue;
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]");
                throw notFoundException;
            }
            if (fromCurrency == "INR")
            {
                if (dictionary.ContainsKey(key))
                    return dictionary[key] * Currencyvalue;
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]");
                throw notFoundException;
            }
            if (dictionary.ContainsKey("INR" + fromCurrency))
                return dictionary["INR" + fromCurrency] / dictionary["INR" + toCurrency] * Currencyvalue;
            else
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]");
                throw notFoundException;
            }
            

        }
    }
}

