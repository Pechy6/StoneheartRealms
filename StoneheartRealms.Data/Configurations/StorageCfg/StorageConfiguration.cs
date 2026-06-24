using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneheartRealms.Data.Entities.Storage;

namespace StoneheartRealms.Data.Configurations.StorageCfg; 

public class StorageConfiguration: IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.HasKey(s => s.Id);

        builder.
            Property(s => s.Name).
            HasMaxLength(20).
            IsRequired();

        builder.
            HasMany(s => s.Resources).
            WithOne(r => r.Storage).
            HasForeignKey(r => r.StorageId);
    }
}