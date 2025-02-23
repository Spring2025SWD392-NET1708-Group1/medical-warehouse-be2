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

            builder.Property(lr => lr.StockInDate)
                .IsRequired();

            builder.Property(lr => lr.Quality)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(lr => lr.Status)
                .IsRequired();

            // Relationship: LotRequest -> Item (Required)
            builder.HasOne(lr => lr.Item)
                .WithMany() // No navigation property in Item
                .HasForeignKey(lr => lr.ItemId)
                .OnDelete(DeleteBehavior.Cascade); // Delete LotRequest if Item is deleted

            // Relationship: LotRequest -> Staff (User)
            builder.HasOne(lr => lr.Staff)
                .WithMany() // No need to track LotRequests in User
                .HasForeignKey(lr => lr.StaffId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting User if there are LotRequests
        }
    }


}
