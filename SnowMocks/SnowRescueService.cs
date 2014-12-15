using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnowMocks.Dependencies;

namespace SnowMocks
{
    public class SnowRescueService
    {
        private readonly IWeatherForecastService weatherForecastService;
        private readonly IMunicipalServices municipalServices;

        public SnowRescueService(IWeatherForecastService weatherForecastService, IMunicipalServices municipalServices)
        {
            this.weatherForecastService = weatherForecastService;
            this.municipalServices = municipalServices;
        }

        public void CheckForecastAndRescue()
        {
            municipalServices.SendSander();
        }
    }
}
