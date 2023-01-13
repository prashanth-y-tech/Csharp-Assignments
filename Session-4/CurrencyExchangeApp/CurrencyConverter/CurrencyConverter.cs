using Newtonsoft.Json;
using System;
using RestSharp;
using System.Configuration;
using System.Collections.Generic;
using System.IO;


namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        private static string GetFilePath()
        {
            DateTime dateTime = DateTime.Now;
            string fileName = dateTime.ToString("MM/dd/yyyy") + ".txt";
            string filePath = Path.Combine(ConfigurationManager.AppSettings["FilePath"], fileName);
            return filePath;
        }

        private static ApiResponse GetApidata()
        {
            RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
            RestRequest request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
            apiResponse.quotes.Add("timestamp", apiResponse.timestamp);
            return apiResponse;
        }

        private static double GetCurrRate(Dictionary<string, double> currRates, string toCurrency, string fromCurrency)
        {
            string currencyStamp1 = "INR" + fromCurrency;
            string currencyStamp2 = "INR" + toCurrency;
            if (currencyStamp1 != "INRINR" && !currRates.ContainsKey(currencyStamp1))
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{fromCurrency}] invalid.", fromCurrency);
                throw notFoundException;
            }
            if (currencyStamp2 != "INRINR" && !currRates.ContainsKey(currencyStamp2))
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{toCurrency}] invalid.", toCurrency);
                throw notFoundException;
            }
            if (toCurrency.Equals("INR") && currRates.ContainsKey(toCurrency + fromCurrency))
            {
                return 1.0 / currRates[toCurrency + fromCurrency];
            }
            if (fromCurrency.Equals("INR") && currRates.ContainsKey(fromCurrency + toCurrency))
            {
                return currRates[fromCurrency + toCurrency];
            }
            return currRates["INR" + fromCurrency] / currRates["INR" + toCurrency];
        }

        public static double Convert(string fromCurrency, string toCurrency, double currencyValue)
        {
            if (toCurrency.Equals(fromCurrency))
            {
                return currencyValue;
            }

            Dictionary<string, double> exchangeRates;

            if (!File.Exists(GetFilePath()))
            {
                ApiResponse apiResponse = apiResponse = GetApidata();
                File.WriteAllText(GetFilePath(), JsonConvert.SerializeObject(apiResponse.quotes));
                exchangeRates = apiResponse.quotes;
            }
            else
            {
                exchangeRates = JsonConvert.DeserializeObject<Dictionary<string, double>>(File.ReadAllText(GetFilePath()));
            }
            double fileConvertedCurrency = GetCurrRate(exchangeRates, fromCurrency, toCurrency);
            return fileConvertedCurrency * currencyValue;
        }
    }
}

