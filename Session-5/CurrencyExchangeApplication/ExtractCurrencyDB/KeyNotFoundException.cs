using System;

namespace CurrencyExchange
{
    public class KeyNotFoundException : Exception
    {
        public string CurrencyCode { get; set; }
        public KeyNotFoundException()
        {
        }
        public KeyNotFoundException(string message, string currencyCode) : base(message)
        {
            this.CurrencyCode = currencyCode;
        }
    }
}
