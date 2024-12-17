namespace api.Models;

public class CreateOrderRequest
{
    public required string CustomerName { get; set; }
    public required DateTime OrderDate { get; set; }
    public required List<CreateOrderItemRequest> Items { get; set; }
    public required double Total { get; set; }
    public required string CreditCardNumber { get; set; }
}

public class CreateOrderItemRequest
{
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required double Price { get; set; }
}
