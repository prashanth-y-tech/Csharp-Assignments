using RestSharp;
using Newtonsoft.Json;


namespace CurrencyExchange
{
    public class CurrencyConverter
    {
        public static double Convert(string fromCurrency, string toCurrency, double currencyValue)
        {
            string currencyStamp = $"{toCurrency}{fromCurrency}";
            var client = new RestClient($"https://api.apilayer.com/currency_data/live?source={toCurrency}&currencies={fromCurrency}");
            var request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse apiObject;
            RestResponse response = client.Get(request);
            apiObject = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            if (apiObject.success==true)
            {
                if(toCurrency == fromCurrency)
                {
                    return 1 * currencyValue;
                }
                double curr_val = apiObject.quotes[currencyStamp];
                return curr_val * currencyValue;
            }
            else if (apiObject.success == false)
            {
                CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]",currencyStamp);
                throw notFoundException;
            }
            return 0.00;
        }
    }
}

