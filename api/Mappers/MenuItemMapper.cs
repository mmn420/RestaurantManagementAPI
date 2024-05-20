using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.MenuItem;
using api.Models;

namespace api.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemDto ToMenuItemDto (this MenuItem menuItem)
        {
            return new MenuItemDto {
                Id = menuItem.Id,
                ItemName = menuItem.ItemName,
                ItemPrice = menuItem.ItemPrice
            };
        }
    }
}