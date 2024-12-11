using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class News : IEntity
    {
        public int ID { get; set; }
        [Display(Name = "Adı")]

        public string Name { get; set; }
        [Display(Name = "Açıklama")]

        public string? Description { get; set; }
        [Display(Name = "Resim")]

        public string? Image { get; set; }
        [Display(Name = "Aktif?")]

        public bool IsActive { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; }

    }
}
