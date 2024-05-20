using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.OrderItem;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderItemsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<OrderItemsDto?> AddItemToOrder(OrderItemsDto orderItemDto)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderItemDto.OrderId);
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == orderItemDto.MenuItemId);
            if(order == null || menuItem == null)
            {
                return null;
            }

            var orderItem = new OrderMenuItem 
            {
                OrderId = orderItemDto.OrderId,
                MenuItemId = orderItemDto.MenuItemId,
                Quantity = orderItemDto.Quantity
            };
            await _context.OrderMenuItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.ToOrderItemsDto();
        }

        public async Task<OrderItemsDto?> DeleteOrderItemAsync(int orderId, int itemId)
        {
            var orderItem = await _context.OrderMenuItems.FirstOrDefaultAsync(x => x.OrderId == orderId && x.MenuItemId == itemId);
            if(orderItem == null)
            {
                return null;
            }
            _context.OrderMenuItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return orderItem.ToOrderItemsDto();
        }

        public async Task<List<OrderItemsDto>> GetAllAsync()
        {
            var orderItems = await _context.OrderMenuItems.ToListAsync();
            return orderItems.Select(oi => oi.ToOrderItemsDto()).ToList();

        }

        public async Task<OrderItemsDto?> GetOrderItemByIdAsync(int orderId, int itemId)
        {
            var orderItem = await _context.OrderMenuItems.FirstOrDefaultAsync(x => x.OrderId == orderId && x.MenuItemId == itemId);
            if(orderItem == null)
            {
                return null;
            }
            return orderItem.ToOrderItemsDto();
        }

        public async Task<OrderItemsDto?> UpdateOrderItemAsync(OrderItemsDto orderItemDto)
        {
            var existingOrderItem = await _context.OrderMenuItems.FirstOrDefaultAsync(x => x.OrderId == orderItemDto.OrderId && x.MenuItemId == orderItemDto.MenuItemId);
            if(existingOrderItem == null)
            {
                return null;
            }
            existingOrderItem.Quantity = orderItemDto.Quantity;
            await _context.SaveChangesAsync();
            return existingOrderItem.ToOrderItemsDto();
        }
    }
}