using System.Collections.Generic;



namespace CurrencyExchange
{
    public class ApiResponse
    {
        public Dictionary<string, double> quotes { get; set; }
#nullable enable
        public object? error { get; set; }
#nullable disable
        public bool success { get; set; }

        
    }
}
