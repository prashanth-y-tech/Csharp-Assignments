using System;

namespace CurrencyConverter
{
    public class CurrrencyNotFoundException : Exception
    {
        public CurrrencyNotFoundException()
        {
        }
        public string CurrencyCode { get; set; }
        public CurrrencyNotFoundException(string message, string currencyCode)
          : base(message)
        {
            this.CurrencyCode = currencyCode;
        }
    }
}
