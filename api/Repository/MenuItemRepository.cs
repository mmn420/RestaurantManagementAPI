using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers;
using api.Data;
using api.DTOs.MenuItem;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDBContext _context;

        public MenuItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<MenuItem> AddMenuItemAsync(CreateMenuItemDto menuItem)
        {
            MenuItem newMenuItem = new MenuItem {
                ItemName = menuItem.ItemName,
                ItemPrice = menuItem.ItemPrice
            };

            await _context.MenuItems.AddAsync(newMenuItem);
            await _context.SaveChangesAsync();
            return newMenuItem;
        }

        public async Task<MenuItem?> DeleteMenuItemAsync(int id)
        {
            var existingItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if (existingItem == null)
            {
                return null;
            }
            else
            {
                _context.MenuItems.Remove(existingItem);
                await _context.SaveChangesAsync();
                return existingItem;
            }
        }

        public async Task<List<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
        {
            var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if (menuItem == null)
            {
                return null;
            }
            else
            {
                return menuItem;
            }
        }

        public async Task<MenuItem?> UpdateMenuItemAsync(int id ,CreateMenuItemDto menuItemDto)
        {
            var existingMenuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMenuItem == null)
            {
                return null;
            }
            else
            {
                existingMenuItem.ItemName = menuItemDto.ItemName;
                existingMenuItem.ItemPrice = menuItemDto.ItemPrice;
                await _context.SaveChangesAsync();
                return existingMenuItem;
            }
        }
    }
}