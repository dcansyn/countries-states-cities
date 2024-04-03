namespace Dummy.Provider.Services.Location.Models;

public class CityModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
