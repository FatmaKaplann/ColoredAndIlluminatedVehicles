using DataAccess;
using Entities.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business;

public class BoatService
{
    private readonly Context _context;

    public BoatService(Context context)
    {
        this._context = context;
    }

    public async Task<Result<BoatDto[]>> ListBoatsByColor(string colorFilter)
    {      
        var isValidColor = Enum.TryParse(colorFilter, true, out VehicleColor color);
        if (!isValidColor)
            return new Result<BoatDto[]>
            {
                Message = "Geçersiz renk",
            };

        var boats = _context
                    .Boats
                    .AsNoTracking()                   
                    .Where(c => c.Color == color);

        if (!boats.Any())
            return new Result<BoatDto[]>
            {
                IsSuccessful = false,
                Message = "Uygun kayıt bulunamadı",
            };

        var result = await boats.Select(c => new BoatDto
        {
            ID = c.ID,
            Color = c.Color.ToString(),
            AreHeadlightsOn = c.AreHeadlightsOn           
           
        }).ToArrayAsync();

        return new Result<BoatDto[]>
        {
            IsSuccessful = true,
            Data = result,
        };
    }
}
