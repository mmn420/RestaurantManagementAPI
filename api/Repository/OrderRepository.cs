using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Order;
using api.DTOs.OrderItem;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(CreateOrderDto orderDto)
        {
            var orderItemModelList = new List<OrderMenuItem>();
            foreach(var item in orderDto.orderItemsList)
            {
                orderItemModelList.Add(new OrderMenuItem {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity
                });
            }

            var order = new Order 
            {
                TableId = orderDto.TableId,
                UserId = orderDto.UserId,
                OrderStatus = orderDto.OrderStatus,
                OrderMenuItems = orderItemModelList
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> DeleteOrder(int id)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOrder == null)
            {
                return null;
            }

            _context.Orders.Remove(existingOrder);
            await _context.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var order = await _context.Orders
            .Include(x => x.OrderMenuItems)
            .ThenInclude(x => x.MenuItem)
            .FirstOrDefaultAsync(x => x.Id == id);
            if(order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
            .Include(x => x.OrderMenuItems)
            .ToListAsync();
        }

        public async Task<Order?> UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var existingOrder = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (existingOrder == null)
            {
                return null;
            }
            existingOrder.OrderStatus = updateOrderDto.OrderStatus;
            await _context.SaveChangesAsync();
            return existingOrder;
        }
    }
}