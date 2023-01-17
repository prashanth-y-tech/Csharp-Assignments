namespace ExtractCurrencyDB
{
    public class DbSchema
    {
        public string Currency  {get; set;}
        public double Rate { get; set; }
        public string TimeStamp { get; set; }

        public DbSchema(string currency, double rate, string timeStamp)
        {
            Currency = currency;
            Rate = rate;
            TimeStamp = timeStamp;
        }
    }
}
