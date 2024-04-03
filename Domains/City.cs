using Dummy.Core.Data.Audition;
using Dummy.Core.Data.Log.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.Domain.Locations;

[Table("Cities")]
public class City : DeletionAuditedBase<Guid>
{
    [LogIgnore]
    public State State { get; protected set; } = default!;
    public Guid StateId { get; protected set; }

    public string Name { get; protected set; } = default!;

    public double Latitude { get; protected set; }
    public double Longitude { get; protected set; }

    public City() { }

    public City(
        Guid stateId,
        string name,
        double latitude,
        double longitude)
    {
        StateId = stateId;
        Name = name.Trim();
        Latitude = latitude;
        Longitude = longitude;

        SetCreationTime();
        SetModificationTime();
    }
}
