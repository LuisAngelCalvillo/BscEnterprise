using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            ResponseDataDto<List<OrderDto>> response = new();
            response = await _orderService.GetAllOrdersAsync();

            if (!response.Completed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(InsertOrderDetailDto order)
        {
            ResponseDto response = new();
            response = await _orderService.InsertOrderAsync(order);

            if (!response.Completed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get/{idOrder}")]
        public async Task<IActionResult> Get(int idOrder)
        {
            ResponseDataDto<List<DetailOrderResponse>> response = new();
            response = await _orderService.GetDetailOrder(idOrder);

            if (!response.Completed)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
