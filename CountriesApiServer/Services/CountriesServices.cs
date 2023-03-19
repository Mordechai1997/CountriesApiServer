using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using CountriesApiServer.Models;

namespace CountriesApiServer.Services
{
    public class CountriesServices
    {
        private IConfiguration _configuration { get; }
        private static Logger _logger;
        private string _baseUrl;
        public CountriesServices(IConfiguration iConfig)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _configuration = iConfig;
            _baseUrl = _configuration.GetValue<string>("apiUrl");
        }
        public async Task<List<Country>> GetCountries()
        {
            string apiUrl = $"{_baseUrl}region/Asia";
            var data = await GetHttpDataFromUrl(apiUrl);
            List<Country> allCountries = JsonConvert.DeserializeObject<List<Country>>(data);
            return allCountries;
        }
        public async Task<List<Country>> GetCountryByName(string name)
        {
            string apiUrl = $"{_baseUrl}name/{name}";
            var data = await GetHttpDataFromUrl(apiUrl);
            List<Country> allCountries = JsonConvert.DeserializeObject<List<Country>>(data);
            return allCountries;
        }
        private async Task<string> GetHttpDataFromUrl(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            return data;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"GetHttpDataFromUrl failed: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
