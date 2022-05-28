using BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IGeolocateIpManager
    {
        string GetCallerIp();
        string GetListGeolocations(string[] ipAddresses);
    }
}
