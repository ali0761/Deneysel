//Önce CicekSepeti.Core sınıfımızda Entities klasörünü oluşturduk sonra içini sınıflarımızla doldurduk sonra ciceksepeti.data sınıfında configurations klasörünü oluşturduk içindi doldurduk

using CicekSepeti.Core.Entities;   //Entities deki appuser i kullanacağımız için buraya ekledik 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CicekSepeti.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>    //IEntityTypeConfiguration<AppUser> bunu ekledikten sonra implament ediyoruz alttaki Configure metodunu
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);   //IsRequaired girişi zorunlu kılıyor
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Phone).HasColumnType("varchar(15)").HasMaxLength(15);               //Telefon zorunlu değil IsRequaired e gerek yok
            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);
            builder.Property(x => x.UserName).HasColumnType("varchar(50)").HasMaxLength(50);

            builder.HasData(             //Başlangıç kullanıcımızı oluşturmamızı sağlayan metot Admin yani
                new AppUser  
                {
                    ID = 1,
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Test",
                    Password = "123456*",
                    Surname = "User"
                }
                );

        }
    }
}
