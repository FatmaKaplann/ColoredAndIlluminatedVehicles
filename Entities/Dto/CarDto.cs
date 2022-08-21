namespace Entities.Dto;

public class CarDto 
{
    //Her bir arabanın IDsi, rengi, farlarının açık/kapalı olma durumu ve tekerlekleri var.
    public int ID { get; set; }
    public string Color { get; set; }
    public bool AreHeadlightsOn { get; set; }
    public WheelDto[] Wheels { get; set; }
}
