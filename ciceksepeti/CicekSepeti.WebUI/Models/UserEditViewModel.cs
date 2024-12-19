using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.WebUI.Models
{
    public class UserEditViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        //burda ve diğer altı yeşil olan değişkenlere değer vermemiz gerekiyor appuserconfigurations sınıfında, yoksa veritabanında hata veriyor
        public string Surname { get; set; }            //mesela phone alanı zorunlu değil değer vermesek de olur appuserconfg sınıfında
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }                  // ? koymamızın nedeni kullanıcı boş geçebilir diye
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
