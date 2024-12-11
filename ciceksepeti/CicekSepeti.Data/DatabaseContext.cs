using CicekSepeti.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace CicekSepeti.Data
{
    public class DatabaseContext : DbContext      //veritabanı nesnelerimizi tutacağımız yer
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News>  News { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Slider>  Sliders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)    //veritabanı bağlantı ayarı yaptığımız yer
        {
            optionsBuilder.UseSqlServer("Server=MSI-THIN;Database=CicekSepetiDb;Trusted_Connection=True; TrustServerCertificate=True;");

            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore
            (RelationalEventId.PendingModelChangesWarning));



            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)              //oluşturduğumuz configuration sınıflarını tanıtıyoruz
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
