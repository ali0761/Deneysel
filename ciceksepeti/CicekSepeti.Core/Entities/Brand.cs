using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class Brand : IEntity    //implament etmeyi unutma 
    {
        public int ID { get; set; }
        [Display(Name = "Adı")]

        public string Name { get; set; }
        [Display(Name = "Açıklama")]

        public string? Description { get; set; }          //marka ismi zorunlu değil
        public string? Logo { get; set; }
        [Display(Name = "Aktif?")]

        public bool IsActive { get; set; }
        [Display(Name = "Sıra No")]

        public int OrderNo { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; } = DateTime.Now;
		public IList<Product>? Products { get; set; }



    }
}
