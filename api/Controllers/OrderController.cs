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
        return Ok(GetOrderResponses());
    }

    [HttpPost]
    public ActionResult<IEnumerable<OrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            _orderService.CreateOrder(request);
            return Ok(GetOrderResponses());
        }
        catch
        {
            return Ok(new List<OrderResponse>
            {
                new(new Order
                {
                    id = Guid.NewGuid(),
                    customer_name = "Error",
                    order_date = DateTime.Now,
                    items = [],
                    total = 0,
                    credit_card_number = "Error"
                })
            });
        }
    }

    private IEnumerable<OrderResponse> GetOrderResponses() =>
        _orderService.GetOrders().Select(order => new OrderResponse(order));
}