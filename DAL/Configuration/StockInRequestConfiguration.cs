using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class StockInRequestConfiguration : IEntityTypeConfiguration<StockInRequest>
    {
        public void Configure(EntityTypeBuilder<StockInRequest> builder)
        {
            builder.ToTable("StockInRequests");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired();

            builder.Property(s => s.UserId)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithMany(u => u.StockInRequests)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.ItemId)
                .IsRequired();

            builder.HasOne(s => s.Item)
                .WithMany() // Adjust if Item has a collection of StockInRequests
                .HasForeignKey(s => s.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Quantity)
                .IsRequired();

            builder.Property(s => s.Note)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.ExpiryDate)
                .IsRequired();

            builder.Property(s => s.Status)
                .IsRequired();
            builder.Property(s => s.CreatedAt)
                .IsRequired();
        }
    }
}
