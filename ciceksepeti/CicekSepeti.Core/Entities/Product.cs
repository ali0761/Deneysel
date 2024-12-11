﻿using System.ComponentModel.DataAnnotations;

namespace CicekSepeti.Core.Entities
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        [Display(Name = "Adı")]

        public string Name { get; set; }
        [Display(Name = "Açıklama")]

        public string? Description { get; set; }          //marka ismi zorunlu değil
        [Display(Name = "Resim")]

        public string? Image { get; set; }
        [Display(Name = "Fiyat")]

        public decimal Price { get; set; }
        [Display(Name = "Ürün Kodu")]

        public string? ProductCode { get; set; }
        [Display(Name = "Stok")]

        public int Stock { get; set; }
        [Display(Name = "Aktif?")]

        public bool IsActive { get; set; }
        [Display(Name = "Anasayfada Göster ")]

        public bool IsHome { get; set; }
        [Display(Name = "Kategori")]

        public int? CategoryID { get; set; }
        [Display(Name = "Kategori")]

        public Category? Category { get; set; }
        [Display(Name = "Marka")]

        public int? BrandID { get; set; }
        [Display(Name = "Marka")]

        public Brand? Brand { get; set; }
        [Display(Name = "Sıra No")]

        public int OrderNo { get; set; }
        [Display(Name = "Kayıt Tarihi"), ScaffoldColumn(false)]

        public DateTime CreateDate { get; set; } = DateTime.Now;
	}
}
