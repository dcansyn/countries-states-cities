using Dummy.Core.Data.Audition;
using Dummy.Core.Data.Log.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.Domain.Locations;

[Table("Countries")]
public class Country : DeletionAuditedBase<Guid>
{
    [LogIgnore]
    public Region? Region { get; protected set; }
    public Guid? RegionId { get; protected set; }

    [LogIgnore]
    public SubRegion? SubRegion { get; protected set; }
    public Guid? SubRegionId { get; protected set; }

    public string Name { get; protected set; } = default!;
    public string Iso3 { get; protected set; } = default!;
    public string Iso2 { get; protected set; } = default!;
    public int NumericCode { get; protected set; }
    public string PhoneCode { get; protected set; } = default!;
    public string Capital { get; protected set; } = default!;
    public string Currency { get; protected set; } = default!;
    public string CurrencyName { get; protected set; } = default!;
    public string CurrencySymbol { get; protected set; } = default!;
    public string Domain { get; protected set; } = default!;
    public string Native { get; protected set; } = default!;
    public string Nationality { get; protected set; } = default!;
    public string TimeZones { get; protected set; } = default!;
    public string Translations { get; protected set; } = default!;
    public string Emoji { get; protected set; } = default!;
    public string EmojiUnicode { get; protected set; } = default!;
    public double Latitude { get; protected set; }
    public double Longitude { get; protected set; }

    [LogIgnore]
    [InverseProperty("Country")]
    public ICollection<State> States { get; set; } = default!;

    public Country() { }

    public Country(
        Guid? regionId,
        Guid? subRegionId,
        string name,
        string iso3,
        string iso2,
        int numericCode,
        string phoneCode,
        string capital,
        string currency,
        string currencyName,
        string currencySymbol,
        string domain,
        string native,
        string nationality,
        string timeZones,
        string translations,
        string emoji,
        string emojiUnicode,
        double latitude,
        double longitude)
    {
        RegionId = regionId;
        SubRegionId = subRegionId;
        Name = name;
        Iso3 = iso3;
        Iso2 = iso2;
        NumericCode = numericCode;
        PhoneCode = phoneCode;
        Capital = capital;
        Currency = currency;
        CurrencyName = currencyName;
        CurrencySymbol = currencySymbol;
        Domain = domain;
        Native = native;
        Nationality = nationality;
        TimeZones = timeZones;
        Translations = translations;
        Emoji = emoji;
        EmojiUnicode = emojiUnicode;
        Latitude = latitude;
        Longitude = longitude;

        SetCreationTime();
        SetModificationTime();
    }
}
