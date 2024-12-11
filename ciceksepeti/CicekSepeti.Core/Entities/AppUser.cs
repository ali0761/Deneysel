using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class AppUser : IEntity
    {
        public int ID { get; set; }
        [Display(Name="Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        //burda ve diğer altı yeşil olan değişkenlere değer vermemiz gerekiyor appuserconfigurations sınıfında, yoksa veritabanında hata veriyor
        public string Surname { get; set; }            //mesela phone alanı zorunlu değil değer vermesek de olur appuserconfg sınıfında
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }                  // ? koymamızın nedeni kullanıcı boş geçebilir diye
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kayıt Tarihi"),ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }  = Guid.NewGuid();  //eğer boşsa yeni bir guid değer oluştursun

    }
}
