namespace api.Models;

public class OrderResponse
{
    public OrderResponse(Order order)
    {
        Id = order.id;
        CustomerName = order.customer_name;
        OrderDate = order.order_date;
        Items = order.items;
        Total = order.total;
        CreditCardNumber = order.credit_card_number;
    }

    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public DateTime OrderDate { get; private set; }
    public IEnumerable<OrderItem> Items { get; private set; }
    public double Total { get; private set; }
    public string CreditCardNumber { get; private set; }
}