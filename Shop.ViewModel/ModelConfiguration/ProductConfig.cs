using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;


namespace Shop.Core.ModelConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(ED => ED.id);
            builder.Property(ED=> ED.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(ED=> ED.Description)
                .IsRequired()
                .HasMaxLength(5000)
                .IsUnicode(true);


            builder.Property(ED => ED.Rate)
                .IsRequired();

            builder.Property(ED => ED.Amount)
                .IsRequired();


        
        }
    }
}
