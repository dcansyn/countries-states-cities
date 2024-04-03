using Dummy.Core.Data.Audition;
using Dummy.Core.Data.Log.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.Domain.Locations;

[Table("States")]
public class State : DeletionAuditedBase<Guid>
{
    [LogIgnore]
    public Country Country { get; protected set; } = default!;
    public Guid CountryId { get; protected set; }

    public string Name { get; protected set; } = default!;
    public string Code { get; protected set; } = default!;
    public string? Type { get; protected set; }
    public double? Latitude { get; protected set; }
    public double? Longitude { get; protected set; }

    [LogIgnore]
    [InverseProperty("State")]
    public ICollection<City> Cities { get; set; } = default!;

    public State() { }

    public State(
        Guid countryId,
        string name,
        string code,
        string? type,
        double? latitude,
        double? longitude)
    {
        CountryId = countryId;
        Name = name.Trim();
        Code = code.Trim();
        Type = type?.Trim();
        Latitude = latitude;
        Longitude = longitude;

        SetCreationTime();
        SetModificationTime();
    }
}
