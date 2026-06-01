using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneheartRealms.Data.Entities.Creatures;

namespace StoneheartRealms.Data.Configurations;

public class DwarfConfiguration : IEntityTypeConfiguration<Dwarf>
{
    public void Configure(EntityTypeBuilder<Dwarf> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.
            Property(d => d.Name).
            HasMaxLength(20).
            IsRequired();

        builder.
            Property(d => d.Description).
            HasMaxLength(250);

        builder.
            HasOne(d => d.Job).
            WithMany(j => j.Dwarves).
            HasForeignKey(d => d.JobId);

        builder.
            Property(d => d.Energy).
            HasDefaultValue(100).
            IsRequired();

        builder.
            Property(d => d.Thirst).
            HasDefaultValue(100).
            IsRequired();

        builder.
            Property(d => d.Hunger).
            HasDefaultValue(100).
            IsRequired();

        builder.
            Property(d => d.Gender).
            IsRequired();
    }
}