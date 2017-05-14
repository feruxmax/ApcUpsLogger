using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApcUpsLogger.Engine;

namespace ApcUpsLogger.Controllers
{
    [Route("api/[controller]")]
    public class ApcDeviceController : Controller
    {
        private readonly ApcDevice apcDevice;

        public ApcDeviceController()
        {
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
            return apcDevice.GetParamValue("LINEV");
        }
    }
}
