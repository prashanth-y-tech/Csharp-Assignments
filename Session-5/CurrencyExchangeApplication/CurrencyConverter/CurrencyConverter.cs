using Newtonsoft.Json;
using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;


namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        private static List<Tuple<string, double, int>> GetApidata()
        {
            RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
            RestRequest request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
            var currencyRatesList = apiResponse.quotes.Select(x => new Tuple<string, double, int>(x.Key, x.Value, apiResponse.timestamp)).ToList();
            return currencyRatesList;
        }

        private static double ExtractExchangeValue(string currencyStamp)
        {
            string connString = "server = 127.0.0.1; uid = root; pwd = 12345; database = CURRENCY_EXCHANGE;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand mySqlCommand = new MySqlCommand($"SELECT RATE FROM CURRENCY_RATES WHERE CURRENCY = \"{currencyStamp}\"", conn);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                double exchangeRate = reader.GetDouble(0);
                conn.Close();
                return exchangeRate;
            }
            return -1;
        }
        public static dynamic ConvertCurrency(string fromCurrency, string toCurrency, double currencyValue)
        {
            if (fromCurrency.Equals(toCurrency))
            {
                return currencyValue;
            }
            string connString = "server = 127.0.0.1; uid = root; pwd = 12345; database = CURRENCY_EXCHANGE;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand createCommand = new MySqlCommand("CREATE TABLE IF NOT EXISTS CURRENCY_RATES (CURRENCY VARCHAR(100), RATE DOUBLE, TIME_STAMP int DEFAULT NULL)", conn);
            int isCreated = createCommand.ExecuteNonQuery();
            if (isCreated != 0)
            {
                foreach (Tuple<string, double, int> currencyRate in CurrencyExchange.CurrencyConverter.GetApidata())
                {
                    MySqlCommand insertCommand = new MySqlCommand($"insert into CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES ({$"\"{currencyRate.Item1}\""},{currencyRate.Item2},{currencyRate.Item3});", conn);
                    insertCommand.ExecuteNonQuery();
                }
            }
            MySqlCommand getTimestamp = new MySqlCommand("SELECT TIME_STAMP FROM CURRENCY_RATES;", conn);
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(((Convert.ToInt32(getTimestamp.ExecuteScalar()))));
            if (DateTime.Now.ToString("M/d/yyyy") != dateTime.ToString("M/d/yyyy"))
            {
                MySqlCommand truncateTable = new MySqlCommand("TRUNCATE TABLE CURRENCY_RATES;", conn);
                truncateTable.ExecuteNonQuery();
                foreach (Tuple<string, double, int> currencyRate in CurrencyExchange.CurrencyConverter.GetApidata())
                {
                    MySqlCommand insertCommand = new MySqlCommand($"insert into CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES ({$"\"{currencyRate.Item1}\""},{currencyRate.Item2},{currencyRate.Item3});", conn);
                    insertCommand.ExecuteNonQuery();
                }
            }

            string currencyStamp1 = "INR" + fromCurrency;
            string currencyStamp2 = "INR" + toCurrency;

            if (currencyStamp1 != "INRINR" && ExtractExchangeValue(currencyStamp1) == -1)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{fromCurrency}] invalid.", fromCurrency);
                throw notFoundException;
            }
            if (currencyStamp2 != "INRINR" && ExtractExchangeValue(currencyStamp2) == -1)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{toCurrency}] invalid.", toCurrency);
                throw notFoundException;
            }
            if (toCurrency == "INR")
            {
                double currval = ExtractExchangeValue(toCurrency + fromCurrency);
                return (1.0 / currval * currencyValue);
            }
            if (fromCurrency == "INR")
            {
                double currval = ExtractExchangeValue(fromCurrency + toCurrency);
                return (currval * currencyValue);
            }
            double inrToCurrencyValue = ExtractExchangeValue("INR" + fromCurrency);
            double inrFromCurrencyValue = ExtractExchangeValue("INR" + toCurrency);
            return inrToCurrencyValue / inrFromCurrencyValue * currencyValue;
        }
    }
}
