using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CurrencyExchange
{
    public class CurrencyExchangeDB
    {
        private static string connString;
        public CurrencyExchangeDB()
        {
            connString = ConfigurationManager.AppSettings["ConnString"];
        }
       
        public double ExtractExchangeValue(string currencyStamp)
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(@"SELECT RATE FROM CURRENCY_RATES WHERE CURRENCY = @CURR AND TIME_STAMP = @TIME", connection);
            mySqlCommand.Parameters.AddWithValue("@CURR", currencyStamp);
            mySqlCommand.Parameters.AddWithValue("@TIME", DateTime.Now.Date);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                double exchangeRate = reader.GetDouble(0);
                connection.Close();
                return exchangeRate;
            }
            KeyNotFoundException noKeyException = new KeyNotFoundException($"Key: {currencyStamp} not found", currencyStamp);
            throw noKeyException;
        }

        public void InsertData(List<ExchangeRateDBO> data)
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
           
                foreach (ExchangeRateDBO currencyRate in data)
                {
                    MySqlCommand insertCommand = new MySqlCommand(@"INSERT INTO CURRENCY_RATES (CURRENCY, RATE, TIME_STAMP) VALUES (@CURR,@RATE,@TIME);", connection);
                    insertCommand.Parameters.AddWithValue("@CURR", currencyRate.Currency);
                    insertCommand.Parameters.AddWithValue("@RATE", currencyRate.Rate);
                    insertCommand.Parameters.AddWithValue("@TIME", DateTime.Now.Date);
                    insertCommand.ExecuteNonQuery();
                }
                connection.Close();
            
            return;
        }
    }
}
