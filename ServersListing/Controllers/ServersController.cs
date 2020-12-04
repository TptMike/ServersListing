using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServersListing.DAL;
using ServersListing.Data;

namespace ServersListing.Controllers
{
    public class ServersController : Controller
    {
        private ApplicationDbContext _db;
        public ServersController(ApplicationDbContext ctx)
        {
            _db = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/servers/all")]
        public IActionResult GetAll()
        {
            ServerInfoDAL _dal = new ServerInfoDAL(_db);
            return Ok(_dal.GetAll());
        }
    }
}
