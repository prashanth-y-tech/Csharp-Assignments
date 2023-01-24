using System;
namespace CurrencyExchange
{
    public class ExchangeRateDBO
    {
        public string Currency  {get; set;}
        public double Rate { get; set; }
        public DateTime ExchangeRateDate { get; set; }
        public ExchangeRateDBO(string currency, double rate, DateTime timeStamp)
        {
            Currency = currency;
            Rate = rate;
            ExchangeRateDate = timeStamp;
        }
    }
}