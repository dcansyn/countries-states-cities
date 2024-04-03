using Dummy.Core.Data.Audition;
using Dummy.Core.Data.Log.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dummy.Domain.Locations;

[Table("Regions")]
public class Region : DeletionAuditedBase<Guid>
{
    public string Name { get; protected set; } = default!;
    public string Translations { get; protected set; } = default!;

    [LogIgnore]
    [InverseProperty("Region")]
    public ICollection<Country> Countries { get; set; } = default!;

    public Region() { }

    public Region(string name, string translations)
    {
        Name = name;
        Translations = translations;

        SetCreationTime();
        SetModificationTime();
    }
}
