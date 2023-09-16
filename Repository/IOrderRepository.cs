using LightHeight.Model.DTO;

namespace LightHeight.Repository
{
    public interface IOrderRepository
    {
        Task<OrderDTO> PlaceOrder(int bookId, int quantity);
        Task<OrderDTO> OrderStatus(int orderId);
    }
}
