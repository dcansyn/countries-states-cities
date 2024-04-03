using Newtonsoft.Json;

namespace Dummy.Provider.Services.Location.Models;

public class CountryModel
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Iso3 { get; set; } = default!;
    public string Iso2 { get; set; } = default!;
    [JsonProperty("numeric_code")]
    public int NumericCode { get; set; }
    [JsonProperty("phone_code")]
    public string PhoneCode { get; set; } = default!;
    public string Capital { get; set; } = default!;
    public string Currency { get; set; } = default!;
    [JsonProperty("currency_name")]
    public string CurrencyName { get; set; } = default!;
    [JsonProperty("currency_symbol")]
    public string CurrencySymbol { get; set; } = default!;
    [JsonProperty("tld")]
    public string Domain { get; set; } = default!;
    public string Native { get; set; } = default!;
    public string? Region { get; set; }
    [JsonProperty("region_id")]
    public int? RegionId { get; set; }
    public string? SubRegion { get; set; }
    [JsonProperty("subregion_id")]
    public int? SubRegionId { get; set; }
    public string Nationality { get; set; } = default!;
    public TimeZoneModel[] TimeZones { get; set; } = default!;
    public Dictionary<string, string> Translations { get; set; } = default!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Emoji { get; set; } = default!;
    [JsonProperty("emojiU")]
    public string EmojiUnicode { get; set; } = default!;

    public StateModel[] States { get; set; } = default!;
}
