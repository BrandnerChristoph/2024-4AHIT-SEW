using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public ExampleController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }


    // GET: api/Example/1
    [HttpGet("{id}")]
    [Authorize]
    public ActionResult<WeatherForecast> Get(int id)
    {
        if (id == 1)
        {
            return Ok(new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("Random")]
    public ActionResult<KVP> GetRandomInt()
    {
        Random rnd = new Random();
        KVP kvp = new KVP("RandomInt", rnd.Next(0, 5001).ToString());
        return Ok(kvp);        
    }

    [HttpGet]
    [Route("Random/{num}")]
    public ActionResult<List<KVP>> GetMultipleRandomInt(int num = 1)
    {
        try
        {
            List<KVP> items = new List<KVP>();
            for (int i = 0; i < num; i++)
            {
                Random rnd = new Random();
                items.Add(new KVP("RandomInt", rnd.Next(0, 5001).ToString()));
            }
            return Ok(items);
        } catch
        {
            return NotFound();
        }
    }

    public class KVP
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public KVP( string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

}
