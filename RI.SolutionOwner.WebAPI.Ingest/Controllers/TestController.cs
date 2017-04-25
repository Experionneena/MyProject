using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("Test/Index")]
        public string Index()
        {
            return "Welcome to test 1.0.0 - The Combleat Sheep Tracking Suite";
        }
    }
}
