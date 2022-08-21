using Business;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AlphaStellar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoatsController : ControllerBase
{
    private readonly BoatService _boatService;
    private readonly Context _context;
    bool statu = false;

    public BoatsController(BoatService boatService, Context context)
    {
        this._boatService = boatService;
        this._context = context;
    }

    [HttpGet("{color}")]
    public async Task<IActionResult> ListBoat(string color)
    {
        var result = await _boatService.ListBoatsByColor(color);

        if (!result.IsSuccessful)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }
    [HttpDelete("boats/{id}")]
    public IActionResult RemoveBoats(int id)
    {

        var boatList = _context.Boats.ToList();
        var RemoveBoat = boatList.Where(x => x.ID == id).FirstOrDefault();
        if (RemoveBoat != null)
        {
            boatList.Remove(RemoveBoat);
            _context.Remove(boatList.Where(x => x.ID == id).FirstOrDefault());
        }
        else
            return BadRequest("Tekne bulunamadı.");

        return Ok("Seçilen Tekne Silindi.");
       
        _context.SaveChanges();

    }

    [HttpPost("{id}")]
    public IActionResult Turn(int id)
    {
        
        var boatList = _context.Boats.ToList();
        var TurnLights = boatList.Where(x => x.ID == id).FirstOrDefault();

        if (TurnLights != null)
        {
            statu = true;
            TurnLights.AreHeadlightsOn = true;
        }
        else
            TurnLights.AreHeadlightsOn = false;
        _context.SaveChanges();
        return Ok("Renk değiştirildi.");
    }

}
