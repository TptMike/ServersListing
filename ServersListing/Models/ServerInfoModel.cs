using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServersListing.Models
{
    public class ServerInfoModel
    {
        public int Id { get; set; }
        public string ServerTypeName { get; set; }
        public string ServerHostName { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public List<ServerService> Services { get; set; }
    }
}
