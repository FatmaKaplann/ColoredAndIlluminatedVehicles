using Business;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AlphaStellar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusesController : ControllerBase
{
    private readonly BusService _busService;
    public readonly Context _context;

    public BusesController(BusService busService, Context context)
    {
        this._busService = busService;
        this._context = context;
    }

    [HttpGet("{color}")]
    public async Task<IActionResult> ListBus(string color)
    {
        var result = await _busService.ListBusesByColor(color);

        if (!result.IsSuccessful)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }
    [HttpDelete("{id}")]
    public IActionResult RemoveBuses(int id)
    {

        var busList = _context.Buses.ToList();
        var RemoveBus = busList.Where(x => x.ID == id).FirstOrDefault();
        if (RemoveBus != null) { 
            _context.Remove(RemoveBus); 
            busList.Remove(RemoveBus); 
        }
        else
            return BadRequest("Otobüs bulunamadı.");
        
        _context.SaveChanges();
        return Ok("Seçilen Otobüs Silindi.");

    }

    [HttpPost("{id}")]
    public IActionResult Turn(int id)
    {
        bool statu = false;
        var busList = _context.Buses.ToList();
        var TurnLights = busList.Where(x => x.ID == id).FirstOrDefault();

        if (TurnLights != null)
        {

            TurnLights.AreHeadlightsOn = true;
            statu = true;
        }
        else
            TurnLights.AreHeadlightsOn = false;
        _context.SaveChanges(statu);
        return Ok("Renk değiştirildi.");
    }
}
