using ServersListing.Data;
using ServersListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServersListing.DAL
{
    public class ServerServiceDAL
    {
        private ApplicationDbContext _db;
        public ServerServiceDAL(ApplicationDbContext ctx)
        {
            _db = ctx;
        }
        public List<ServerService> GetAllById(int id)
        {
            return null;
        }
    }
}
