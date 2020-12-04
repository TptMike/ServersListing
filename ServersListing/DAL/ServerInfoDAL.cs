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
                var servers = (from serverinfo in _db.ServerInfo
                               join stype in _db.ServerType on serverinfo.ServerTypeId equals stype.Id
                               select new ServerInfoModel { 
                                   Id = serverinfo.Id,
                                   ServerHostName = serverinfo.ServerHostName,
                                   ServerTypeName = stype.OSName,
                                   IPAddress = serverinfo.IPAddress,
                                   Description = serverinfo.Description
                               }).ToList();


                /*
                 * 
                 * SELECT ss.ServiceName, ss.Label, si.ServerHostName FROM ServerInfo si
                   JOIN ServerServiceInfo ssi ON ssi.ServerInfoId = si.Id
                   JOIN ServerService ss ON ssi.ServerServiceId = ss.Id
                   WHERE si.Id = 2;
                 * 
                 */

                var serverServices = (from si in _db.ServerInfo
                               join ssi in _db.ServerServiceinfo on si.Id equals ssi.ServerInfoId
                               join ss in _db.ServerService on ssi.ServerServiceId equals ss.Id
                               select new ServerServiceInfoDTO
                               {
                                   Id = ssi.ServerServiceId,
                                   ServiceName = ss.ServiceName,
                                   Label = ss.Label,
                                   ServerInfoId = si.Id
                               }).ToList();

                foreach (ServerInfoModel server in servers)
                {
                    // Search list of DTOs and filter down to list of services
                    var filteredServices = serverServices.Where(ss => ss.ServerInfoId == server.Id).ToList();
                    if(server.Services == null)
                    {
                        server.Services = new List<ServerService>();
                    }
                    foreach (var filteredService in filteredServices)
                    {
                        server.Services.Add(new ServerService
                        {
                            Id = filteredService.Id,
                            ServiceName = filteredService.ServiceName,
                            Label = filteredService.Label
                        });
                    }
                }


                return servers;
            }
        }
    }
}
