using Dummy.Core.Data.Audition;
using Dummy.Core.Data.Log.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.Domain.Locations;

[Table("SubRegion")]
public class SubRegion : DeletionAuditedBase<Guid>
{
    [LogIgnore]
    public Region Region { get; protected set; } = default!;
    public Guid RegionId { get; protected set; }

    public string Name { get; protected set; } = default!;
    public string Translations { get; protected set; } = default!;

    [LogIgnore]
    [InverseProperty("SubRegion")]
    public ICollection<Country> Countries { get; set; } = default!;

    public SubRegion(Guid regionId, string name, string translations)
    {
        RegionId = regionId;
        Name = name;
        Translations = translations;

        SetCreationTime();
        SetModificationTime();
    }
}
