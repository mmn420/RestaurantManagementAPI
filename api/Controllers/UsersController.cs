using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute]int id)
        {
           
            var user = await _userRepo.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
           
            User newUser = new User{
                Name = userDto.Name,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
            };
            var user = await _userRepo.CreateUserAsync(newUser);
            return Ok(user);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto userDto)
        {
            // if(!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            var user = await _userRepo.UpdateUserAsync(id, userDto);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
           
            var user = await _userRepo.DeleteUserAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


    }
}