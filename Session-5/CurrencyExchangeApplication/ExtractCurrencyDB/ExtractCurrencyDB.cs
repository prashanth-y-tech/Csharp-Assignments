using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CurrencyExchange
{
    public class CurrencyExchangeDB
    {
        private string connString;

        public CurrencyExchangeDB(string connectionString)
        {
            connString = connectionString;
        }
       
        public double GetExchangeRate(string currencyStamp)
        {
            using(MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(@"SELECT RATE FROM CURRENCY_RATES WHERE CURRENCY = @CURR AND EXCHANGERATEDATE = @TIME", connection);
                mySqlCommand.Parameters.AddWithValue("@CURR", currencyStamp);
                mySqlCommand.Parameters.AddWithValue("@TIME", DateTime.Now.Date);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    double exchangeRate = reader.GetDouble(0);
                    return exchangeRate;
                }
                RecordNotFoundException noRecordException = new RecordNotFoundException($"Record : {currencyStamp} not found", currencyStamp);
                throw noRecordException;
            }
        }

        public void InsertExchangeRates(List<ExchangeRateDBO> data)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                foreach (ExchangeRateDBO currencyRate in data)
                {
                    MySqlCommand insertCommand = new MySqlCommand(@"INSERT INTO CURRENCY_RATES (CURRENCY, RATE, EXCHANGERATEDATE) VALUES (@CURR,@RATE,@TIME);", connection);
                    insertCommand.Parameters.AddWithValue("@CURR", currencyRate.Currency);
                    insertCommand.Parameters.AddWithValue("@RATE", currencyRate.Rate);
                    insertCommand.Parameters.AddWithValue("@TIME", DateTime.Now.Date);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
