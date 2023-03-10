using _3_Asp.Net_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace _3_Asp.Net_MVC.Configurations
{
    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Product).WithMany().
                HasForeignKey(p => p.IdSP);
            builder.HasOne(p => p.Cart).WithMany().
                HasForeignKey(p => p.UserId);
        }
    }
}
