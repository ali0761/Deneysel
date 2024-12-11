using CicekSepeti.Core.Entities;   //Entities deki Slider ı kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {

            builder.Property(x => x.Title).HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.Link).HasMaxLength(100);
            //SliderConfg ile de bütün yapılandırmaları bitirmiş olduk şimdi sıra veritabanıda
        }
    }
}
