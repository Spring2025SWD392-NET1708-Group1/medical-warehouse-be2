using Common.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .IsRequired()
                .HasDefaultValue(LotRequestEnums.Draft)
                .HasConversion<int>();

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

            builder.HasData(
                new LotRequest
                {
                    LotRequestId = Guid.Parse("f4e4b2a5-3f2c-4b6a-9d6e-73e3c98f5291"),
                    StockInDate = new DateTime(2025, 03, 10),
                    Quality = "Good",
                    ItemId = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"), // Paracetamol
                    Status = LotRequestEnums.Reported,
                    StaffId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8fc") // xhuyz (admin@example.com)
                },
                new LotRequest
                {
                    LotRequestId = Guid.Parse("bd3a6eb2-df79-4f52-9a06-8d5d7f1b1e29"),
                    StockInDate = new DateTime(2025, 04, 05),
                    Quality = "Excellent",
                    ItemId = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"), // Surgical Gloves
                    Status = LotRequestEnums.Approved,
                    StaffId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8fc") // xhuyz (admin@example.com)
                }
            );

        }
    }


}
