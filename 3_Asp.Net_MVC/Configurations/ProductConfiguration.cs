using _3_Asp.Net_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _3_Asp.Net_MVC.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Supplier).IsUnicode(true).
                IsFixedLength().HasMaxLength(1000);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
            // 2 đoạn config trên là như nhau
        }
    }
}
