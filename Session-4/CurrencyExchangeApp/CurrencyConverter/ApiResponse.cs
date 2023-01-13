using System.Collections.Generic;


namespace CurrencyExchange
{
    public class ErrorType
    {
        public int code;
        public string info;
    }

    public class ApiResponse
    {
        public Dictionary<string, double> quotes { get; set; }
        public ErrorType error { get; set; }
        public bool success { get; set; }
        public double timestamp { get; set; }
    }
}
