using CicekSepeti.Core.Entities;
using CicekSepeti.Service.Abstract;

namespace CicekSepeti.Service.Concrate
{
	public class CartService : ICartService
	{
		public List<CartLine> CartLines = new();
		public void AddProduct(Product product, int quantity)
		{
			var urun = CartLines.FirstOrDefault(p=>p.Product.ID == product.ID);
			if (urun != null) 
			{
				urun.Quantity += quantity;
			}
			else
			{
				CartLines.Add(new CartLine
				{
					Quantity = quantity,
					Product = product
				});
			}
		}

		public void ClearAll()
		{
			CartLines.Clear();
		}

		public void RemoveProduct(Product producty)
		{
			CartLines.RemoveAll(p=>p.Product.ID == producty.ID);
		}

		public decimal TotalPrice()
		{
			return CartLines.Sum(c=>c.Product.Price*c.Quantity);
		}

		public void UpdateProduct(Product product, int quantity)
		{
			var urun = CartLines.FirstOrDefault(p => p.Product.ID == product.ID);
			if (urun != null)
			{
				urun.Quantity = quantity;
			}
			else
			{
				CartLines.Add(new CartLine
				{
					Quantity = quantity,
					Product = product
				});
			}
		}
	}
}
