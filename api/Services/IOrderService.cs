using api.Models;

namespace api.Services;

public interface IOrderService
{
    IEnumerable<Order> GetOrders();
    Order CreateOrder(CreateOrderRequest request);
}