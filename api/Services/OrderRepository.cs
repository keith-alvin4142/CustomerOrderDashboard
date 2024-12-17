using api.Models;

namespace api.Services;

// Ignore the mock data, pretend this is a real database
public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders =
    [
        new Order
        {
            id = Guid.NewGuid(),
            customer_name = "John Smith",
            order_date = DateTime.Parse("2024-03-15T10:30:00"),
            items =
            [
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Widget",
                    Quantity = 2,
                    Price = 10
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Gadget",
                    Quantity = 1,
                    Price = 20
                }
            ],
            total = 40
        },

        new Order
        {
            id = Guid.NewGuid(),
            customer_name = "Jane Doe",
            order_date = DateTime.Parse("2024-03-14T15:45:00"),
            items =
            [
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Thingamajig",
                    Quantity = 3,
                    Price = 15
                }
            ],
            total = 45
        }
    ];

    public IEnumerable<Order> GetAll()
    {
        return _orders;
    }

    public Order Add(Order order)
    {
        _orders.Add(order);
        return order;
    }
}
