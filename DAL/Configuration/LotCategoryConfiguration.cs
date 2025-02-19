using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public class LotCategoryConfiguration : IEntityTypeConfiguration<LotCategory>
    {
        public void Configure(EntityTypeBuilder<LotCategory> builder)
        {
            // Primary Key
            builder.HasKey(lc => lc.Id);

            // Properties
            builder.Property(lc => lc.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            builder.HasMany(lc => lc.Requests)
                .WithOne(r => r.LotCategory) // Assuming LotRequest has a navigation property LotCategory
                .HasForeignKey(r => r.LotCategoryID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
