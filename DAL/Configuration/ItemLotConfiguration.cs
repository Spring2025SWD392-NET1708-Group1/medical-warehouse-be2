using Common.Enums;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ItemLotConfiguration : IEntityTypeConfiguration<ItemLot>
    {
        public void Configure(EntityTypeBuilder<ItemLot> builder)
        {
            builder.HasKey(il => il.ItemLotId);


            builder.Property(il => il.Quality)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(il => il.Status)
                .IsRequired()
                .HasDefaultValue(LotStatus.NeedChecking)
                .HasConversion<int>();

            // Relationship: LotRequest -> Item (Required)
            builder.HasOne(il => il.Item)
                .WithMany() // No navigation property in Item
                .HasForeignKey(lr => lr.ItemId)
                .OnDelete(DeleteBehavior.Cascade); // Delete LotRequest if Item is deleted

            builder.HasOne(il => il.Storage)
                .WithMany(s => s.ItemLots)
                .HasForeignKey(il => il.StorageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new ItemLot
                {
                    ItemLotId = Guid.Parse("f4e4b2a5-3f2c-4b6a-9d6e-73e3c98f5291"),
                    Quality = Quality.Good,
                    ItemId = Guid.Parse("80c0ac22-9f4d-478e-8fe1-f01b4e6727b0"), // Paracetamol
                    Status = LotStatus.Pending,
                    StorageId = 1,
                    Quantity = 200,
                    ExpiryDate = new DateTime(2025, 12, 31) // Example: Expiry end of 2025
                },
                new ItemLot
                {
                    ItemLotId = Guid.Parse("bd3a6eb2-df79-4f52-9a06-8d5d7f1b1e29"),
                    Quality = Quality.Good,
                    ItemId = Guid.Parse("1bfe3b07-5419-4718-bed9-0439016c7f78"), // Surgical Gloves
                    Status = LotStatus.InStorage,
                    StorageId = 2,
                    Quantity = 200,
                    ExpiryDate = new DateTime(2026, 06, 30) // Example: Expiry mid-2026
                }
            );

        }
    }


}
