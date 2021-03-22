using DotMenu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotMenu.Repositories.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.ToTable("Users");
        }
    }
}