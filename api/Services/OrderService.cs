using api.Models;

namespace api.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
        _logger = new Logger<OrderService>(new LoggerFactory());
    }

    public IEnumerable<Order> GetOrders()
    {
        return _repository.GetAll();
    }

    public Order CreateOrder(CreateOrderRequest request)
    {
        _logger.LogInformation("Credit card number: {Number}", request.CreditCardNumber);

        var order = new Order
        {
            id = Guid.NewGuid(),
            customer_name = "Keith Carsley",
            order_date = request.OrderDate,
            items = request.Items.Select(item => new OrderItem
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList(),
            total = request.Total
        };

        return _repository.Add(order);
    }
}