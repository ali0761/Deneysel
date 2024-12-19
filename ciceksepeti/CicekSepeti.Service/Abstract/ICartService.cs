using CicekSepeti.Core.Entities;

namespace CicekSepeti.Service.Abstract
{
	public interface ICartService
	{
		void AddProduct(Product product, int quantity);
		void UpdateProduct(Product product, int quantity);
		void RemoveProduct(Product producty);
		decimal TotalPrice();
		void ClearAll();
	}
}
