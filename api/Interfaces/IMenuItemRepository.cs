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
        Task<List<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem?> GetMenuItemByIdAsync(int id);
        Task<MenuItem> AddMenuItemAsync(CreateMenuItemDto menuItem);
        Task<MenuItem?> UpdateMenuItemAsync(int id ,CreateMenuItemDto menuItemDto);
        Task<MenuItem?> DeleteMenuItemAsync(int id);
    }
}