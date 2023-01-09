using System.Collections.Generic;



namespace CurrencyConverter
{
    internal class ApiResponse
    { 
        public Dictionary<string, double> quotes { get; set; }
#nullable enable
        public object? error { get; set; }
#nullable disable
        public bool success { get; set; }

        
    }
}
