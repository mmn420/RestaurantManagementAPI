using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.OrderItem;
using api.Models;

namespace api.Mappers
{
    public static class OrderItemsMapper
    {
        public static OrderItemsDto ToOrderItemsDto(this OrderMenuItem orderItems)
        {
            return new OrderItemsDto
            {
                OrderId = orderItems.OrderId,
                MenuItemId = orderItems.MenuItemId,
                Quantity = orderItems.Quantity
            };
        }
    }
}