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
        Task<Order> CreateOrder(CreateOrderDto orderDto);
        Task<Order?> UpdateOrder(int id, UpdateOrderDto orderDto);
        Task<Order?> DeleteOrder(int id);
        Task<List<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
    }
}