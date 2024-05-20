using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.MenuItem;
using api.Models;

namespace api.Controllers
{
    public interface IMenuItemRepository
    {
        Task<List<MenuItemDto>> GetAllMenuItemsAsync();
        Task<MenuItemDto?> GetMenuItemByIdAsync(int id);
        Task<MenuItemDto> AddMenuItemAsync(CreateMenuItemDto menuItem);
        Task<MenuItemDto?> UpdateMenuItemAsync(int id ,CreateMenuItemDto menuItemDto);
        Task<MenuItemDto?> DeleteMenuItemAsync(int id);
    }
}