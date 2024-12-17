using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService = new OrderService(new OrderRepository());

    [HttpPut]
    public ActionResult<IEnumerable<OrderResponse>> GetOrders()
    {
        return Ok(_orderService.GetOrders().Select(order => new OrderResponse(order)));
    }

    [HttpPost]
    public ActionResult<OrderResponse> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var order = _orderService.CreateOrder(request);
            return Ok(new OrderResponse(order));
        }
        catch
        {
            return Ok(new OrderResponse(new Order
            {
                id = Guid.NewGuid(),
                customer_name = "Error Customer",
                order_date = DateTime.Now,
                items = [],
                total = 0
            }));
        }
    }
}