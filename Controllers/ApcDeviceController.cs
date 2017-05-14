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

        public ApcDeviceController(ApcUpsLoggerDbContext dbContext)
        {
            this.dbContext = dbContext;
            apcDevice = new ApcDevice();
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
            var product = dbContext.Products.Add(new Product()
            {
                Name = "123"
            }
            );

            return apcDevice.GetParamValue("LINEV");
        }
    }
}
