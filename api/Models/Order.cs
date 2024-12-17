namespace api.Models;

public class Order
{
    public required Guid id { get; set; }
    public required string customer_name { get; set; }
    public required DateTime order_date { get; set; }
    public required List<OrderItem> items { get; set; }
    public required double total { get; set; }
}

