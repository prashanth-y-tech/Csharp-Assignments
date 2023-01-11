using System;
using System.Collections.Generic;



namespace CurrencyConverter
{
    public class ApiResponse
    {
        public Dictionary<string, double> quotes { get; set; }
        //public List<Tuple<string,double>> quotes { get; set; }
#nullable enable
        public object? error { get; set; }
#nullable disable
        public bool success { get; set; }
        public double timestamp { get; set; }


    }
}
