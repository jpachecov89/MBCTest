using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class GeolocateRequest
    {
        public IEnumerable<Geolocate> Geolocates { get; set; }
    }
}
