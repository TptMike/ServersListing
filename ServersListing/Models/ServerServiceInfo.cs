using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServersListing.Models
{
    public class ServerServiceInfo
    {
        [Key, Column(Order = 0)]
        public int ServerInfoId { get; set; }
        [Key, Column(Order = 1)]
        public int ServerServiceId { get; set; }
    }
}
