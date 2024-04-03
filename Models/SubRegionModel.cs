namespace Dummy.Provider.Services.Location.Models;

public class SubRegionModel
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public string Name { get; set; } = default!;
    public Dictionary<string, string> Translations { get; set; } = default!;
    public string WikiDataId { get; set; } = default!;

    public CountryModel[] Countries { get; set; } = default!;
}
