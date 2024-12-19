using CicekSepeti.Core.Entities;

namespace CicekSepeti.WebUI.Models
{
	public class CheckoutViewModel
	{
		public List<CartLine>? CartProducts { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
