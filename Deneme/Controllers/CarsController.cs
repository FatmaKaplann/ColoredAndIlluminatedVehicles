using Business;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AlphaStellar.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarService _carService;
    public readonly Context _context;

    public CarsController(CarService carService, Context context)
    {
        this._carService = carService;
        this._context = context;
    }

    [HttpGet("{color}")]
    public async Task<IActionResult> ListCars(string color)
    {
        var result = await _carService.ListCarsByColor(color);

        if (!result.IsSuccessful)
            return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCars(int id)
    {

        var carList = _context.Cars.ToList();
        var RemoveCar = carList.Where(x => x.ID == id).FirstOrDefault();
        if (RemoveCar != null)
        {
            carList.Remove(RemoveCar);
            _context.Remove(RemoveCar);
        }
        else
            return BadRequest("Araba bulunamadı.");
       
        _context.SaveChanges();
        return Ok("Seçilen Araba Silindi.");

    }

    [HttpPost("{id}")]
    public IActionResult Turn(int id)
    {
        bool statu = false;
        var carList = _context.Cars.ToList();
        var TurnLights = carList.Where(x => x.ID == id).FirstOrDefault();

        if (TurnLights != null)
        {
            TurnLights.AreHeadlightsOn = true;
            statu = true;
        }
        else
            TurnLights.AreHeadlightsOn = false;
        _context.SaveChanges(statu);
        return Ok("Renk değiştirildi");
    }
}
