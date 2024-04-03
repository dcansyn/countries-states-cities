using Newtonsoft.Json;

namespace Dummy.Provider.Services.Location.Models;

public class TimeZoneModel
{
    public string Name { get; set; } = default!;
    [JsonProperty("zoneName")]
    public string ZoneName { get; set; } = default!;
    [JsonProperty("gmtOffset")]
    public int TimeOffsetSeconds { get; set; }
    [JsonProperty("gmtOffsetName")]
    public string TimeOffsetName { get; set; } = default!;
    public string Abbreviation { get; set; } = default!;
}