using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class Slider : IEntity
    {
        public int ID { get; set; }
        [Display(Name = "Başlık")]
        public string? Title { get; set; }
        [Display(Name = "Açıklama")]

        public string? Description { get; set; }
        [Display(Name = "Resim")]


        public string? Image { get; set; }
        public string? Link { get; set; }          //resme tıklandığında açılacak sayfayı tutan alan olacak



    }
}
