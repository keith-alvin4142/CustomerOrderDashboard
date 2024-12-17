using api.Models;

namespace api.Services;

public interface IOrderService
{
    IEnumerable<Order> GetOrders();
    void CreateOrder(CreateOrderRequest request);
}