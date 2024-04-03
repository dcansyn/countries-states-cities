using Newtonsoft.Json;

namespace Dummy.Provider.Services.Location.Models;

public class StateModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    [JsonProperty("state_code")]
    public string Code { get; set; } = default!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Type { get; set; }

    public CityModel[] Cities { get; set; } = default!;
}
