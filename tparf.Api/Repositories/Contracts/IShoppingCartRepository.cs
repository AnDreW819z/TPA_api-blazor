using tparf.Api.Entities;
using tparf.Models.Dtos;

namespace tparf.Api.Repositories.Contracts
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
