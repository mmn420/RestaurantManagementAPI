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
        Task<OrderItemsDto?> GetOrderItemByIdAsync(int orderId, int itemId);
        Task<OrderItemsDto?> DeleteOrderItemAsync(int orderId, int itemId);
        Task<OrderItemsDto?> UpdateOrderItemAsync(OrderItemsDto orderItemDto);
        Task<OrderItemsDto?> AddItemToOrder(OrderItemsDto orderItemDto);
        Task<List<OrderItemsDto>> GetAllAsync();
    }
}