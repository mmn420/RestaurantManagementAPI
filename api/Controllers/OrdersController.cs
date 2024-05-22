using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.DTOs.OrderItem;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            
            return Ok(await _orderRepo.GetOrders());
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> GetOrderById( [FromRoute] int id)
        {
            
            var order = await _orderRepo.GetOrderById(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> DeleteOrder([FromRoute] int id)
        {
            
            var order = await _orderRepo.DeleteOrder(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> UpdateOrder([FromRoute] int id, [FromBody ]UpdateOrderDto updateOrderDto)
        {
            
            var order = await _orderRepo.UpdateOrder(id, updateOrderDto);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            
            var order = await _orderRepo.CreateOrder(createOrderDto);
            return Ok(order);
        }
    }
}