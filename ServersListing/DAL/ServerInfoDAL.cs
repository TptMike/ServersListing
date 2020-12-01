using ServersListing.Data;
using ServersListing.Models;
using ServersListing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ServersListing.DAL
{
    public class ServerInfoDAL
    {
        private ApplicationDbContext _db;
        public ServerInfoDAL(ApplicationDbContext ctx)
        {
            _db = ctx;
        }
        
        public List<ServerInfoModel> GetAll()
        {
            List<ServerInfoModel> services = new List<ServerInfoModel>();
            using (_db)
            {
                /*
                 * 
                 * SELECT st.OSName, si.ServerHostName, si.IpAddress, si.Description FROM ServerInfo si
                   JOIN ServerType st ON si.ServerTypeId = st.Id;
                 * 
                 */
                var results = (from serverinfo in _db.ServerInfo
                               join stype in _db.ServerType on serverinfo.ServerTypeId equals stype.Id
                               select new ServerInfoModel { 
                                   Id = serverinfo.Id,
                                   ServerHostName = serverinfo.ServerHostName,
                                   ServerTypeName = stype.OSName,
                                   IPAddress = serverinfo.IPAddress,
                                   Description = serverinfo.Description
                               }).ToList();

                return results;
            }
        }
    }
}
