using CicekSepeti.Core.Entities;   //Entities deki News i kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description);
            builder.Property(x => x.Image).HasMaxLength(100);

        }
    }
}
