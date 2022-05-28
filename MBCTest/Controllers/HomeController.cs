using BusinessLayer;
using BusinessLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBCTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGeolocateIpManager _iGeolocation;

        public HomeController(ILogger<HomeController> logger, IGeolocateIpManager iGeolocation)
        {
            _logger = logger;
            _iGeolocation = iGeolocation;
        }

        /// <summary>
        /// GetCallerIp: Returns my ip and the configuration of country serialized
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCallerIp")]
        public ActionResult GetCallerIp()
        {
            try
            {
                return Ok(_iGeolocation.GetCallerIp());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetListGeolocations: Insert an array of ips and return a list of geolocations
        /// </summary>
        /// <param name="ipAddresses">array of ip addresses</param>
        /// <returns></returns>
        [HttpPost("GetListGeolocations")]
        public ActionResult GetListGeolocations([FromBody] string[] ipAddresses)
        {
            try
            {
                return Ok(_iGeolocation.GetListGeolocations(ipAddresses));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
