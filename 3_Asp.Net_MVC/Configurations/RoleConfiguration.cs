using _3_Asp.Net_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _3_Asp.Net_MVC.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(20)");
            builder.HasAlternateKey(x => x.Name); // Unique
            builder.Property(p => p.Description).
                HasColumnType("nvarchar(1000)");
        }
    }
}
