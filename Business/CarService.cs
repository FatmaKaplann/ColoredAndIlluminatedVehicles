using DataAccess;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class CarService
{
    private readonly Context _context;

    public CarService(Context context)
    {
        this._context = context;
    }

    public async Task<Result<CarDto[]>> ListCarsByColor(string colorFilter)
    {
        var isValidColor = Enum.TryParse(colorFilter, true, out VehicleColor color);
        if (!isValidColor)
            return new Result<CarDto[]>
            {
                Message = "Geçersiz renk",
            };

        var cars = _context
                    .Cars
                    .AsNoTracking()
                    .Include(c => c.Wheels)
                    .Where(c => c.Color == color);

        if (!cars.Any())
            return new Result<CarDto[]>
            {
                IsSuccessful = false,
                Message = "Uygun kayıt bulunamadı",
            };

        var result = await cars.Select(c => new CarDto
        {
            ID = c.ID,
            Color = c.Color.ToString(),
            AreHeadlightsOn = c.AreHeadlightsOn,
            Wheels = c.Wheels
            .Select(w => new WheelDto
            {
                Diameter = w.Diameter,
                WheelCount=w.WheelCount
            }).ToArray(),
        }).ToArrayAsync();

        return new Result<CarDto[]>
        {
            IsSuccessful = true,
            Data = result,
        };
    }
}