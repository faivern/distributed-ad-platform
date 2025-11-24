using System.Net.Http.Json;
using System.Text.Json.Serialization;
    public class ExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public ExchangeRateService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["ExchangeRateApi:ApiKey"] ?? string.Empty;
            _baseUrl = _configuration["ExchangeRateApi:BaseUrl"] ?? string.Empty;
        }

        public async Task<decimal> GetSekToAsync(string targetCurrency)
        {
            // No conversion needed
            if (targetCurrency == "SEK")
            {
                return 1m;
            }

         /* 
          * https://www.exchangerate-api.com/docs/pair-conversion-requests
          */
            var url = $"{_baseUrl}/{_apiKey}/pair/SEK/{targetCurrency}";

            var resp = await _httpClient.GetFromJsonAsync<ExchangeRatePairResponse>(url);

            return resp?.ConversionRate ?? 1m;
        }
    }

    public class ExchangeRatePairResponse
    {
        [JsonPropertyName("conversion_rate")]
        public decimal ConversionRate { get; set; }
    }
