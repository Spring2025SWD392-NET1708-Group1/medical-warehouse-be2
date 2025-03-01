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
            builder.HasOne(lr => lr.User)
                .WithMany(u => u.LotRequests)
                .HasForeignKey(lr => lr.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting User if there are LotRequests

            builder.HasOne(lr => lr.Storage)
                .WithMany()
                .HasForeignKey(lr => lr.StorageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new LotRequest
                {
                    LotRequestId = Guid.Parse("f4e4b2a5-3f2c-4b6a-9d6e-73e3c98f5291"),
                    Quality = "Good",
                    ItemId = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"), // Paracetamol
                    Status = LotRequestEnums.Reported,
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f1"), // xhuyz (admin@example.com)
                    StorageId = 1
                },
                new LotRequest
                {
                    LotRequestId = Guid.Parse("bd3a6eb2-df79-4f52-9a06-8d5d7f1b1e29"),
                    Quality = "Excellent",
                    ItemId = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"), // Surgical Gloves
                    Status = LotRequestEnums.Approved,
                    UserId = Guid.Parse("d8f0b849-d1a2-45d5-8a23-47772060c8f1"), // xhuyz (admin@example.com)
                    StorageId = 2
                }
            );

        }
    }


}
