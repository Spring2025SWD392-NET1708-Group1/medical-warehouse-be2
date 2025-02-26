using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
  public class StorageConfiguration : IEntityTypeConfiguration<Storage>
  {
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
      builder.HasKey(s => s.Id);
      builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
      builder.Property(s => s.Capacity).IsRequired();
      builder.Property(s => s.IsActive).IsRequired();

      builder.HasOne(s => s.StorageCategory)
             .WithMany()
             .HasForeignKey(s => s.StorageCategoryId)
             .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
