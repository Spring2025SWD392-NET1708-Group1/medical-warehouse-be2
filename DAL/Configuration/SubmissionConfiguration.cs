using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.FromUserId)
                .IsRequired();

            builder.Property(s => s.Context)
                .IsRequired();

            builder.Property(s => s.CreatedDate)
                .IsRequired();

            builder.HasOne(s => s.FromUser)
                .WithMany(u => u.SentSubmissions)
                .HasForeignKey(s => s.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ToUser)
                .WithMany(u => u.ReceivedSubmissions)
                .HasForeignKey(s => s.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s=> s.Storage)
                .WithMany()
                .HasForeignKey(st => st.StorageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}