using MaxMind.GeoIP2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class Geolocate
    {
        public string IpAddress { get; set; }
        public Country Country { get; set; }
    }
}
