using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesAzure.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInfoController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public object Get()
        {
            return new
            {
                Environment.MachineName,
                SO = Environment.OSVersion.VersionString
            };
        }
    }
}
