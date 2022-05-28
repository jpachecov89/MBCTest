using BusinessLayer.Dto;
using MaxMind.GeoIP2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BusinessLayer
{
    public class GeolocateIpManager : IGeolocateIpManager
    {
        private string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeoLite2-Country.mmdb");
        public string GetCallerIp()
        {
            using (var reader = new DatabaseReader(fullPath))
            {
                string publicIp = GetMyPublicIp();
                var response = reader.Country(publicIp);
                Geolocate callerGeolocalized = new Geolocate
                {
                    IpAddress = publicIp,
                    Country = response.Country
                };
                return JsonConvert.SerializeObject(callerGeolocalized);
            }
        }

        public string GetListGeolocations(string[] ipAddresses)
        {
            using (var reader = new DatabaseReader(fullPath))
            {
                List<Geolocate> geolocations = new List<Geolocate>();
                foreach (string ipAddress in ipAddresses)
                {
                    var response = reader.Country(ipAddress);
                    Geolocate geolocalized = new Geolocate
                    {
                        IpAddress = response.Traits.IPAddress,
                        Country = response.Country
                    };
                    geolocations.Add(geolocalized);
                }
                return JsonConvert.SerializeObject(geolocations);
            }
        }

        private string GetMyPublicIp()
        {
            string publicIp = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    publicIp = stream.ReadToEnd();
                }
                if (!string.IsNullOrEmpty(publicIp))
                {
                    int first = publicIp.IndexOf("Address: ") + 9;
                    int last = publicIp.LastIndexOf("</body>");
                    publicIp = publicIp.Substring(first, last - first);
                }
            }
            return publicIp;
        }
    }
}
