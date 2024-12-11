using CicekSepeti.Core.Entities;   //Entities deki Brand i kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)   //bu builder brand için çalışacak
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Logo).HasMaxLength(50);
            //description zorunlu değil eklemedik o yüzden 
          
        }
    }
}
