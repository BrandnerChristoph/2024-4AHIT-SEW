using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        // GET api/<HelperController>/<Type>
        [HttpGet("{type}")]
        public async Task<ActionResult<Helper>> Get(string type)
        {
            if (type.ToLower() == "time")
                return new Helper(DateTime.Now.ToString());

            if (type.ToLower() == "version")
                return new Helper("0.0.1");


            return new Helper(new Exception("unknown parameter").Message);
        }
    }
}
