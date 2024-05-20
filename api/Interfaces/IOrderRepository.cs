using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.DTOs.OrderItem;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderDto> CreateOrder(CreateOrderDto orderDto);
        Task<OrderDto?> UpdateOrder(int id, UpdateOrderDto orderDto);
        Task<OrderDto?> DeleteOrder(int id);
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto?> GetOrderById(int id);
    }
}