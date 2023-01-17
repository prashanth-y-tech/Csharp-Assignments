using ExtractCurrencyDB;

namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        public static double ConvertCurrency(string fromCurrency, string toCurrency, double currencyValue)
        {
            if (fromCurrency.Equals(toCurrency))
            {
                return currencyValue;
            }

            string currencyStamp1 = "INR" + fromCurrency;
            string currencyStamp2 = "INR" + toCurrency;
            double stamp1CurrencyRate = ExtractCurrencyDB.ExtractExchangeValue(currencyStamp1);
            double stamp2CurrencyRate = ExtractCurrencyDB.ExtractExchangeValue(currencyStamp2); ;
            if (currencyStamp1 != "INRINR" && stamp1CurrencyRate == -1)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{fromCurrency}] invalid.", fromCurrency);
                throw notFoundException;
            }
            if (currencyStamp2 != "INRINR" && stamp2CurrencyRate == -1)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException($"Currency [{toCurrency}] invalid.", toCurrency);
                throw notFoundException;
            }
            if (toCurrency == "INR")
            {
                double currval = stamp1CurrencyRate;
                return (1.0 / currval * currencyValue);
            }
            if (fromCurrency == "INR")
            {
                double currval = stamp2CurrencyRate;
                return (currval * currencyValue);
            }
            double inrToCurrencyValue = stamp1CurrencyRate;
            double inrFromCurrencyValue = stamp2CurrencyRate;
            return inrToCurrencyValue / inrFromCurrencyValue * currencyValue;
        }
    }
}
