using ServersListing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServersListing.Models
{
    public class ServerInfo
    {
        public int Id { get; set; }
        public int ServerTypeId { get; set; }
        public string ServerHostName { get; set; }
        public string IPAddress { get; set; }
        public List<ServerService> Services { get; set; }
        public string Description { get; set; }
    }
}
