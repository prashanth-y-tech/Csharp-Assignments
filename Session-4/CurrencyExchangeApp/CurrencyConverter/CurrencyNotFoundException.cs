using System;

namespace CurrencyExchange
{
    public class CurrrencyNotFoundException : Exception
    {
        public string CurrencyCode { get; set; }
        public CurrrencyNotFoundException()
        {
        }

        public CurrrencyNotFoundException(string message, string currencyCode) : base(message)
        {
            this.CurrencyCode = currencyCode;
        }
    }
}
