using RestSharp;
using Newtonsoft.Json;


namespace CurrencyConverter
{
    public class CurrencyExchange
    {
        public double Convert(string fromCurrency, string toCurrency, double currencyValue)
        {
            CurrrencyNotFoundException notFoundException = new CurrrencyNotFoundException("Enter a valid Currency[Ex : USD, INR]");
            string currencyStamp = $"{toCurrency}{fromCurrency}";
            var client = new RestClient($"https://api.apilayer.com/currency_data/live?source={toCurrency}&currencies={fromCurrency}");
            var request = new RestRequest();
            request.AddHeader("apikey", "NKJlyNE9umLraoNvP87N7W9v6NNePbI8");
            ApiResponse ApiObject;
            RestResponse response = client.Get(request);
            ApiObject = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            if (ApiObject.success==true)
            {
                if(toCurrency == fromCurrency)
                {
                    return 1 * currencyValue;
                }
                double curr_val = ApiObject.quotes[currencyStamp];
                return curr_val * currencyValue;
            }
            else if (ApiObject.success == false)
            {
                throw notFoundException; 
            }
            return 0.00;

            
        }
    }
}

