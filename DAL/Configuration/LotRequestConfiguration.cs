using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public class LotRequestConfiguration : IEntityTypeConfiguration<LotRequest>
    {
        public void Configure(EntityTypeBuilder<LotRequest> builder)
        {
            builder.HasKey(lr => lr.LotRequestId);

            // Properties
            builder.Property(lr => lr.StockInDate)
                .IsRequired();

            builder.Property(lr => lr.Status)
                .IsRequired();

            // Foreign key relationship with LotCategory
            builder.HasOne(lr => lr.LotCategory)
                .WithMany(lc => lc.Requests)  // LotCategory has many LotRequests
                .HasForeignKey(lr => lr.LotCategoryID)  // Foreign key in LotRequest
                .OnDelete(DeleteBehavior.Restrict);  // Adjust delete behavior as needed

            // Define the many-to-many relationship between LotRequest and Item
            builder.HasMany(lr => lr.Items) // LotRequest has many Items
                .WithOne()  // Items do not reference LotRequest (no navigation property)
                .OnDelete(DeleteBehavior.SetNull); // Adjust delete behavior for Item, if necessary
        }
    }
}
