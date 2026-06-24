using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Data.Configurations.StorageCfg;

public class ResourcesConfiguration: IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasKey(r => r.Id);

        builder.
            HasOne(r => r.ResourceType).
            WithMany().
            HasForeignKey(r => r.ResourceTypeId);
    }
}