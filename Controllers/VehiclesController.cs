using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;

namespace VehicleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private static readonly List<Vehicle> Data = [];
    
    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> Get(string? make, int? year)
    {
        var result = Data.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(make))
        {
            result = result.Where(v  => 
                v.Make.Contains (make, StringComparison.OrdinalIgnoreCase));
                
                
        }

        if (year > 0)

        {
            result = result.Where (v =>  v.Year == year);
        }

        return Ok(result.ToList());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Vehicle> GetById(Guid id)
    {
        var vehicle = Data.FirstOrDefault(v => v.Id == id);
        if (vehicle == null) return NotFound();
        return Ok(vehicle);
    }


[HttpPost]
public ActionResult<Vehicle> Create(Vehicle vehicle)
{
    Data.Add(vehicle);
    return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
}

[HttpPut("{id:guid}")]
public IActionResult Replace(Guid id, Vehicle vehicle)
{
    var existing = Data.FirstOrDefault(v => v.Id == id);
    
    if (existing == null) return NotFound();
    existing.Make = vehicle.Make;
    existing.Model = vehicle.Model;
    existing.Year = vehicle.Year;
    
    return NoContent();
}

[HttpDelete("{id:guid}")]
public IActionResult Delete(Guid id)
{
    var existing = Data.FirstOrDefault(v => v.Id == id);
    if (existing == null) return NotFound();
    
    Data.Remove(existing);
    return NoContent();
}

}