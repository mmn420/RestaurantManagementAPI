using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.MenuItem;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/menuitems")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepo;

        public MenuItemsController(IMenuItemRepository menuItemmRepo)
        {
            _menuItemRepo = menuItemmRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemRepo.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById([FromRoute] int id)
        {
            var menuItem = await _menuItemRepo.GetMenuItemByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMenuItem([FromRoute] int id)
        {
            var menuItem = await _menuItemRepo.DeleteMenuItemAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMenuItem([FromBody] CreateMenuItemDto menuItemDto)
        {
            var menuItem = await _menuItemRepo.AddMenuItemAsync(menuItemDto);
            return Ok(menuItem);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMenuItem([FromRoute] int id, [FromBody] CreateMenuItemDto menuItemDto)
        {
            var menuItem = await _menuItemRepo.UpdateMenuItemAsync(id, menuItemDto);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }
    }
}