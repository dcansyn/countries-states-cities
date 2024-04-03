namespace Dummy.Provider.Services.Location.Models;

public class RegionModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public Dictionary<string, string> Translations { get; set; } = default!;
    public string WikiDataId { get; set; } = default!;

    public SubRegionModel[] SubRegions { get; set; } = default!;
}
