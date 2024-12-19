using CicekSepeti.Core.Entities;

namespace CicekSepeti.WebUI.Models
{
	public class CartViewModel
	{
        public List<CartLine>? CartLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
