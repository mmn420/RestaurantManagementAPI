using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.OrderItem;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderItemsRepository
    {
        Task<OrderMenuItem?> GetOrderItemByIdAsync(int orderId, int itemId);
        Task<OrderMenuItem?> DeleteOrderItemAsync(int orderId, int itemId);
        Task<OrderMenuItem?> UpdateOrderItemAsync(OrderItemsDto orderItemDto);
        Task<OrderMenuItem?> AddItemToOrder(OrderItemsDto orderItemDto);
        Task<List<OrderMenuItem>> GetAllAsync();
    }
}