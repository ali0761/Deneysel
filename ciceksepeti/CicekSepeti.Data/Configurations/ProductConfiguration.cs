using CicekSepeti.Core.Entities;   //Entities deki Product ı kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(x => x.Name).HasMaxLength(150);
            //builder.Property(x => x.Description).HasMaxLength(500);   açıklmaa çok uzun olabilir o yüzden girmeye gerek yok 
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.ProductCode).HasMaxLength(50);

        }
    }
}
