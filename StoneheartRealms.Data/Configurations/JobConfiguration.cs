using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneheartRealms.Data.Entities.Jobs;

namespace StoneheartRealms.Data.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasKey(j => j.Id);

        builder.
            Property(j => j.Name).
            HasMaxLength(20).
            IsRequired();

        builder.
            Property(j => j.Description).
            HasMaxLength(250);
    }
}