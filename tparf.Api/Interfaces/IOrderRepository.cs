using tparf.Api.Entities;
using tparf.Models.Dtos.CartItems;
using tparf.Models.Dtos.Orders;

namespace tparf.Api.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateNewOrder(CreateOrderDto orderDto);
        public Task<decimal> AddOrderItem(List<CartItem> cartItems, long orderId);
        Task<Order> UpdateStatus(long id, int status);
        Task<Order> DeleteOrder(long id);
        Task<IEnumerable<Order>> GetOrderByUser(long cartId);
        Task<IEnumerable<OrderItem>> GetOrderItems(long orderId);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<OrderStatus>> GetStatuses();
        Task<Order> GetOrder(long id);
    }
}
