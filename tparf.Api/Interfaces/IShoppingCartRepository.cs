using tparf.Api.Entities;
using tparf.Models.Dtos.CartItems;

namespace tparf.Api.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(long id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(long id);
        Task<CartItem> GetItem(long id);
        Task<IEnumerable<CartItem>> GetItems(long userId);

    }
}
