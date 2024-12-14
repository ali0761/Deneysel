using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class Contact : IEntity
    {
        public int ID { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage ="{0} Alanı boş geçilemez!")]

        public string Name { get; set; }
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Alanı boş geçilemez!")]

        public string Surname { get; set; }
        public string? Email { get; set; }
        [Display(Name = "Telefon")]

        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} Alanı boş geçilemez!")]

        public string Message { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; } = DateTime.Now;   //oluşma zamanını otomatik almamızı sağlar


    }
}
