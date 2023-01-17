using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using ExtractCurrencyDB;

namespace CurrencyExchange
{
    public class ExtractCurrencyDB
    {
        private static string connString;
        ExtractCurrencyDB()
        {
            connString = ConfigurationManager.AppSettings["connString"];
        }

        private static List<DbSchema> GetApidata()
        {
            RestClient client = new RestClient("https://api.apilayer.com/currency_data/live?source=INR&currencies=");
            RestRequest request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(client.Get(request).Content);
            List<DbSchema> dbRates = apiResponse.quotes.Select(x => new DbSchema(x.Key, x.Value, DateTime.Now.ToString("yyyy-MM-dd"))).ToList();
            return dbRates;
        }

        public static double ExtractExchangeValue(string currencyStamp)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand validateCommand = new MySqlCommand(@"SELECT RATE FROM CURRENCY_RATES WHERE TIMESTAMP = @TIME", conn);
            validateCommand.Parameters.AddWithValue("@TIME", DateTime.Now.ToString("yyyy-MM-dd"));
            int isReqData = validateCommand.ExecuteNonQuery();
            if(isReqData == -1)
            {
                InsertIntoDB(GetApidata());
            }
            MySqlCommand mySqlCommand = new MySqlCommand(@"SELECT RATE FROM CURRENCY_RATES WHERE CURRENCY = @CURR AND TIMESTAMP = @TIME", conn);
            mySqlCommand.Parameters.AddWithValue("@CURR", currencyStamp);
            mySqlCommand.Parameters.AddWithValue("@TIME", DateTime.Now.ToString("yyyy-MM-dd"));
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                double exchangeRate = reader.GetDouble(0);
                conn.Close();
                return exchangeRate;
            }
            return -1;
        }
        private static void InsertIntoDB(List<DbSchema> data)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            foreach (DbSchema currencyRate in data)
            {
                MySqlCommand insertCommand = new MySqlCommand(@"INSERT INTO CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES (@CURR,@RATE,@TIME);", conn);
                insertCommand.Parameters.AddWithValue("?CURR", currencyRate.Currency);
                insertCommand.Parameters.AddWithValue("?RATE", currencyRate.Rate);
                insertCommand.Parameters.AddWithValue("?TIME", currencyRate.TimeStamp);
                insertCommand.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
