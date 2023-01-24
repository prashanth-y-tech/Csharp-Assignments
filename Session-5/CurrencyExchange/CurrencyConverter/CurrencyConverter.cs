using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;


namespace CurrencyConverter
{
    public class CurrencyConverter
    {

        public static dynamic GetApidata()
        {
            try
            {
                RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
                RestRequest request = new RestRequest();
                request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
                //apiResponse.quotes.Add(("timestamp", apiResponse.timestamp));
                var list = apiResponse.quotes.Select(x => new Tuple<string, double,double>(x.Key, x.Value,apiResponse.timestamp)).ToList();
                return list;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

        }
        public static double ConvertCurrency(string fromCurrency, string toCurrency, double Currencyvalue)
        {
            
            if (toCurrency == fromCurrency)
                return 1.0;
            string key = fromCurrency + toCurrency;
            try
            {
                string connString = "server = 127.0.0.1; uid = root; pwd = 12345; database = CURRENCY_RATES";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand mySqlCommand2 = new MySqlCommand("SHOW TABLES LIKE \"CURRENCY_RATES\";", conn);
                var tableExists = mySqlCommand2.ExecuteScalar();
                if (tableExists.ToString().ToLower() != "CURRENCY_RATES".ToLower())
                {
                    
                    MySqlCommand mySqlCommand1 = new MySqlCommand("CREATE TABLE CURRENCY_RATES (CURRENCY VARCHAR(100), RATE DOUBLE, TIME_STAMP double DEFAULT NULL);");
                    mySqlCommand1.ExecuteNonQuery();
                    foreach (Tuple<string, double, double> x in GetApidata())
                        {
                            MySqlCommand mySqlCommand = new MySqlCommand($"insert into CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES ({$"\"{x.Item1}\""},{x.Item2},{x.Item3});", conn);
                            mySqlCommand.ExecuteNonQuery();
                        }
                }
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)(Convert.ToInt32(mySqlCommand2.ExecuteScalar())));
                string dateLastRetrieved = dateTime.ToString("M/d/yyyy");
                dateTime = DateTime.Now;
                string dateNow = dateTime.ToString("M/d/yyyy");
                if (dateLastRetrieved != dateNow)
                {
                    
                    foreach (Tuple<string, double, double> x in GetApidata())
                    {
                        MySqlCommand mySqlCommand = new MySqlCommand($"insert into CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES ({$"\"{x.Item1}\""},{x.Item2},{x.Item3});", conn);
                        mySqlCommand.ExecuteNonQuery();
                    }
                }

                Dictionary<string, double> dictionary = new Dictionary<string, double>();
                MySqlCommand getData = new MySqlCommand("SELECT * FROM CURRENCY_RATES;");
                MySqlDataReader reader = getData.ExecuteReader();
                while (reader.Read())
                {
                    dictionary.Add(reader.GetString(0), reader.GetDouble(1));
                }
                if (toCurrency == "INR")
                {
                    if (dictionary.ContainsKey(toCurrency + fromCurrency))
                        return 1.0 / dictionary[toCurrency + fromCurrency] * Currencyvalue;
                    CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]",key);
                    throw notFoundException;
                }
                if (fromCurrency == "INR")
                {
                    if (dictionary.ContainsKey(key))
                        return dictionary[key] * Currencyvalue;
                    CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]", key);
                    throw notFoundException;
                }
                if (dictionary.ContainsKey("INR" + fromCurrency))
                    return dictionary["INR" + fromCurrency] / dictionary["INR" + toCurrency] * Currencyvalue;
                else
                {
                    CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]", key);
                    throw notFoundException;
                }


            }
            catch(Exception e)
            {
                throw e.InnerException;
            }
            return 0.00; 
        }
        






    }
}
