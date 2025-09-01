using Microsoft.AspNetCore.Mvc;

namespace VehicleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }
}