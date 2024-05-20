using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Order;
using api.DTOs.OrderItem;
using api.Models;

namespace api.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order orderModel)
        {
            return new OrderDto{
                Id = orderModel.Id,
                OrderStatus = orderModel.OrderStatus,
                TableId = orderModel.TableId,
                UserId = orderModel.UserId,
                OrderItems = orderModel.OrderMenuItems.Select(oi => oi.ToOrderItemsDto()).ToList()
            };
        }
    }
}