using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
//use newtonsoft to convert json to c# objects.
using Newtonsoft.Json.Linq;
using CountriesApiServer.Services;
using Microsoft.Extensions.Configuration;
using CountriesApiServer.Models;
using NLog;

namespace CountriesApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private static Logger _logger;
        private CountriesServices _services;


        public CountriesController(IConfiguration iConfig)
        {
             _logger = LogManager.GetCurrentClassLogger();
            _services = new CountriesServices(iConfig);
        }



        [HttpGet("getAllCountries")]
        public async Task<ActionResult> GetAllCountries()
        {
            try
            {
                List<Country> allCountries = await _services.GetCountries();
                return Ok(allCountries);
            }
            catch (Exception ex)
            {
                _logger.Error($"GetAllCountries failed: {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet("getCountryByName")]
        public async Task<ActionResult> GetCountryByName(string name)
        {
            try
            {
                List<Country> country = await _services.GetCountryByName(name);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.Error($"GetAllCountries failed: {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
