using Dummy.Core.Helpers;
using Dummy.Data.Default;
using Dummy.Domain.Locations;
using Dummy.Provider.Services.Location.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace Dummy.Provider.Services.Location;

public interface ILocationsService
{
    Task Run();
}

public class LocationsService(DefaultDbContext _context) : ILocationsService
{
    public async Task Run()
    {
        var regionList = GetData<RegionModel[]>("regions");
        var subregionList = GetData<SubRegionModel[]>("subregions");
        var countryList = GetData<CountryModel[]>("countries");

        foreach (var countryItem in countryList)
        {
            await Console.Out.WriteLineAsync($"Country: {countryItem.Name}");
            var regionItem = regionList.FirstOrDefault(x => x.Id == countryItem.RegionId);
            var subRegionItem = subregionList.FirstOrDefault(x => x.Id == countryItem.SubRegionId);

            Guid? regionId = null;
            if (regionItem != null)
            {
                var region = await _context.Regions.FirstOrDefaultAsync(x => x.Name == regionItem.Name);
                if (region == null)
                {
                    region = new Region(regionItem.Name, JsonConvert.SerializeObject(regionItem.Translations));
                    await _context.Regions.AddAsync(region);
                }

                regionId = region.Id;
            }

            Guid? subRegionId = null;
            if (subRegionItem != null && regionId != null)
            {
                var subRegion = await _context.SubRegions.FirstOrDefaultAsync(x => x.Name == subRegionItem.Name);
                if (subRegion == null)
                {
                    subRegion = new SubRegion((Guid)regionId, subRegionItem.Name, JsonConvert.SerializeObject(subRegionItem.Translations));
                    await _context.SubRegions.AddAsync(subRegion);
                }

                subRegionId = subRegion.Id;
            }

            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Iso3 == countryItem.Iso3 && x.Iso2 == countryItem.Iso2);
            if (country == null)
            {
                country = new Country(regionId,
                    subRegionId,
                    countryItem.Name,
                    countryItem.Iso3,
                    countryItem.Iso2,
                    countryItem.NumericCode,
                    countryItem.PhoneCode,
                    countryItem.Capital,
                    countryItem.Currency,
                    countryItem.CurrencyName,
                    countryItem.CurrencySymbol,
                    countryItem.Domain,
                    countryItem.Native,
                    countryItem.Nationality,
                    JsonConvert.SerializeObject(countryItem.TimeZones),
                    JsonConvert.SerializeObject(countryItem.Translations),
                    countryItem.Emoji,
                    countryItem.EmojiUnicode,
                    countryItem.Latitude,
                    countryItem.Longitude);

                await _context.Countries.AddAsync(country);
            }

            foreach (var stateItem in countryItem.States)
            {
                await Console.Out.WriteLineAsync($"State: {stateItem.Name}");
                var state = await _context.States.FirstOrDefaultAsync(x => x.CountryId == country.Id && x.Code == stateItem.Code);
                if (state == null)
                {
                    state = new State(country.Id, stateItem.Name, stateItem.Code, stateItem.Type, stateItem.Latitude, stateItem.Longitude);
                    await _context.States.AddAsync(state);
                }

                foreach (var cityItem in stateItem.Cities)
                {
                    await Console.Out.WriteLineAsync($"City: {cityItem.Name}");
                    var city = await _context.Cities.FirstOrDefaultAsync(x => x.StateId == state.Id && x.Name == cityItem.Name);
                    if (city == null)
                    {
                        city = new City(state.Id, cityItem.Name, cityItem.Latitude, cityItem.Longitude);
                        await _context.Cities.AddAsync(city);
                    }
                }
            }
        }

        await _context.SaveChangesAsync();

        await Console.Out.WriteLineAsync("Done");
    }

    private static T GetData<T>(string fileName)
    {
        var path = Path.Combine(StorageHelper.GetProjectParentDirectory("Dummy.Provider"), "Dummy.Provider", "Data", $"{fileName}.json");
        using var reader = new StreamReader(path, Encoding.UTF8);
        return JsonConvert.DeserializeObject<T>(reader.ReadToEnd()) ?? default!;
    }
}