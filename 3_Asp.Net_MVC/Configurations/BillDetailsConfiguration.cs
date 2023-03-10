using _3_Asp.Net_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _3_Asp.Net_MVC.Configurations
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(p => p.ID);
            // Set thuộc tính
            builder.Property(p=>p.Price).IsRequired().HasColumnType("int");
            builder.Property(p => p.Quantity).IsRequired().HasColumnType("int");
            // Set khóa ngoại - liên kết
            builder.HasOne(p => p.Bill).WithMany(q => q.BillDetails).
                HasForeignKey(p => p.BillID);
            builder.HasOne(p => p.Product).WithMany(q => q.BillDetails).
                HasForeignKey(p => p.ProductID);

        }
    }
}
