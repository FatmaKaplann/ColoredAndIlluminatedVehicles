using DataAccess;
using Entities.Dto;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class BusService
{
    private readonly Context _context;

    public BusService(Context context)
    {
        this._context = context;
    }

    public async Task<Result<BusDto[]>> ListBusesByColor(string colorFilter)
    {
        var isValidColor = Enum.TryParse(colorFilter, true, out VehicleColor color);
        if (!isValidColor)
            return new Result<BusDto[]>
            {
                Message = "Geçersiz renk",
            };

        var buses = _context
                    .Buses
                    .AsNoTracking()
                    .Include(c => c.Wheels)
                    .Where(c => c.Color == color);

        if (!buses.Any())
            return new Result<BusDto[]>
            {
                IsSuccessful = false,
                Message = "Uygun kayıt bulunamadı",
            };

        var result = await buses.Select(c => new BusDto
        {
            ID = c.ID,
            Color = c.Color.ToString(),
            AreHeadlightsOn = c.AreHeadlightsOn,
            Wheels = c.Wheels
            .Select(w => new WheelDto
            {
                Diameter = w.Diameter,
                WheelCount = w.WheelCount

            }).ToArray(),
        }).ToArrayAsync();

        return new Result<BusDto[]>
        {
            IsSuccessful = true,
            Data = result,
        };
    }
}
