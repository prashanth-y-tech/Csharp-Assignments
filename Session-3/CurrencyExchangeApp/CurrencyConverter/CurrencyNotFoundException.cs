using System;

namespace CurrencyConverter
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
