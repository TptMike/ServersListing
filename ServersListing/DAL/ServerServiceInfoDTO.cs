using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServersListing.DAL
{
    public class ServerServiceInfoDTO
    {
        public int Id { get; set; }
        public int ServerInfoId { get; set; }
        public string Label { get; set; }
        public string ServiceName { get; set; }
    }
}
