using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderItem;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/orderitems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsRepository _orderItemsRepo;

        public OrderItemsController(IOrderItemsRepository orderItemsRepo)
        {
            _orderItemsRepo = orderItemsRepo;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrderItem([FromBody] OrderItemsDto orderItemsDto)
        {
            var orderItem = await _orderItemsRepo.AddItemToOrder(orderItemsDto);
            return Ok(orderItem);
        }
        [HttpDelete("{orderId}/{itemId}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int orderId, [FromRoute] int itemId)
        {
            var orderItem = await _orderItemsRepo.DeleteOrderItemAsync(orderId, itemId);
            if(orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
        [HttpGet("{orderId}/{itemId}")]
        public async Task<IActionResult> GetOrderItemById([FromRoute] int orderId, [FromRoute] int itemId)
        {
            var orderItem = await _orderItemsRepo.GetOrderItemByIdAsync(orderId, itemId);
            if(orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderItems()
        {
            var orderItems = await _orderItemsRepo.GetAllAsync();
            return Ok(orderItems);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItemsDto orderItemsDto)
        {
            var orderItem = await _orderItemsRepo.UpdateOrderItemAsync(orderItemsDto);
            if(orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
    }
}