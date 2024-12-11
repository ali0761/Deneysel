using CicekSepeti.Core.Entities;   //Entities deki Category i kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations 
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).HasMaxLength(50);

            builder.HasData(
                new Category
                {
                    Name="Elektronik",
                    ID=1,
                    IsActive=true,
                    IsTopMenu=true,
                    ParentID=0,
                    OrderNo=1,
                },  
                new Category                                //test kategorilerini böyle ekliyoruz
                {
                    Name = "Bilgisayar",
                    ID = 2,
                    IsActive = true,
                    IsTopMenu = true,
                    ParentID = 0,
                    OrderNo = 2,
                }
                );


        }
    }
}
