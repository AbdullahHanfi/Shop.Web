using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ModelConfiguration
{
    public class ProductPhotosConfig : IEntityTypeConfiguration<ProductPhotos>
    {
        public void Configure(EntityTypeBuilder<ProductPhotos> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.product)
           .WithMany(c => c.Photos)
           .HasForeignKey(p => p.ProductId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
