using System;

namespace CurrencyExchange
{
    public class RecordNotFoundException : Exception
    {
        public string RecordKey { get; set; }
        public RecordNotFoundException()
        {
        }
        public RecordNotFoundException(string message, string recordKey) : base(message)
        {
            this.RecordKey = recordKey;
        }
    }
}
