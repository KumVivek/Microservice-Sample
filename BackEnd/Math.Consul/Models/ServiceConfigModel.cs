using System;
using System.Collections.Generic;
using System.Text;

namespace Math.Consul.Models
{
    public class ServiceConfigModel
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
