using CicekSepeti.Core.Entities;

namespace CicekSepeti.WebUI.Models
{
    public class ProductDetailViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<Product>? RelatedProducts  { get; set; }
    }
}
