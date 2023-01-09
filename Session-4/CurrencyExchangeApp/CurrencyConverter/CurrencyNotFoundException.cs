using System;

namespace CurrencyExchange
{
    public class CurrrencyNotFoundException : Exception
    {
        public CurrrencyNotFoundException()
        {
        }

        public CurrrencyNotFoundException(string message)
          : base(message)
        {
        }
    }
}
