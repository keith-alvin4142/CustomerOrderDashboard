using api.Models;

namespace api.Services;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    void Add(Order order);
}