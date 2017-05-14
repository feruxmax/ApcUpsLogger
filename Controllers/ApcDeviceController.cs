using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApcUpsLogger.Engine;
using ApcUpsLogger.DataAccess;

namespace ApcUpsLogger.Controllers
{
    [Route("api/[controller]")]
    public class ApcDeviceController : Controller
    {
        private readonly ApcUpsLoggerDbContext dbContext;
        private readonly ApcDevice apcDevice;

        public ApcDeviceController(ApcUpsLoggerDbContext dbContext, ApcDevice apcDevice)
        {
            this.dbContext = dbContext;
            this.apcDevice = apcDevice;
        }

        // GET api/status
        [HttpGet("status")]
        public string GetStatus()
        {
            return String.Join("", apcDevice.GetStatus());
        }

        // GET api/linev
        [HttpGet("linev")]
        public string GetLineV()
        {
            var livev = apcDevice.GetParamValue("LINEV");
            var product = dbContext.Products.Add(new Product()
            {
                Name = livev
            }
            );
            dbContext.SaveChanges();

            return livev;
        }
    }
}
