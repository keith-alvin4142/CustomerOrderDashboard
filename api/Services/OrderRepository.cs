using api.Models;

namespace api.Services;

// Ignore the mock data, pretend this is a real database
public class OrderRepository : IOrderRepository
{
    private static readonly List<Order> _orders =
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
            total = 40,
            credit_card_number = "1234-5678-9012-3456",
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
            total = 45,
            credit_card_number = "1234-5678-9012-3456",
        }
    ];

    public IEnumerable<Order> GetAll()
    {
        return _orders;
    }

    public void Add(Order order)
    {
        _orders.Add(order);
    }
}
