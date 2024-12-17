namespace api.Models;

public class OrderItem
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Quantity { get; set; }
    public required double Price { get; set; }

    public const string _dbConnString = "Server=prod.db.com;Database=Orders;User=admin;Password=correcthorsebatterystaple";
}
