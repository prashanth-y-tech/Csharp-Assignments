using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        private static List<ExchangeRateDBO> GetApidata()
        {
            RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
            RestRequest request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
            List<ExchangeRateDBO> dbRates = apiResponse.quotes.Select(x => new ExchangeRateDBO(x.Key, x.Value, DateTime.Now)).ToList();
            return dbRates;
        }

        public static double ConvertCurrency(string fromCurrency, string toCurrency, double currencyValue)
        {
            if (fromCurrency.Equals(toCurrency))
            {
                return currencyValue;
            }
            CurrencyExchangeDB DbObject = new CurrencyExchangeDB();
            try
            {
                DbObject.ExtractExchangeValue(ConfigurationManager.AppSettings["StandardCurrency"]);
            }
            catch (Exception)
            {
                DbObject.InsertData(GetApidata());
            }
            string currencyStamp1 = "INR" + fromCurrency;
            string currencyStamp2 = "INR" + toCurrency;
            double stamp1CurrencyRate = 0.0;
            double stamp2CurrencyRate = 0.0;
            try
            {
                if (!currencyStamp1.Equals("INRINR"))
                {   
                    stamp1CurrencyRate = DbObject.ExtractExchangeValue(currencyStamp1);
                }
            }
            catch(Exception)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{fromCurrency}] invalid.", fromCurrency);
                throw notFoundException;
            }
            try
            {
                if (!currencyStamp2.Equals("INRINR"))
                {
                    stamp2CurrencyRate = DbObject.ExtractExchangeValue(currencyStamp2);  
                }
            }
            catch(Exception)
            {
                    CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{toCurrency}] invalid.", toCurrency);
                    throw notFoundException;
            }
            if (toCurrency.Equals("INR"))
            {
                double currval = stamp1CurrencyRate;
                return (1.0 / currval * currencyValue);
            }
            if (fromCurrency.Equals("INR"))
            {
                double currval = stamp2CurrencyRate;
                return (currval * currencyValue);
            }
            double inrToCurrencyValue = stamp1CurrencyRate;
            double inrFromCurrencyValue = stamp2CurrencyRate;
            return inrToCurrencyValue / inrFromCurrencyValue * currencyValue;
        }
    }
}
