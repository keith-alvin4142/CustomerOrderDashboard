using api.Models;

namespace api.Services;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order Add(Order order);
}