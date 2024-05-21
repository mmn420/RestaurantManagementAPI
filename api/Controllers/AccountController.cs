using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _usermanager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                };
                var createdUser = await _usermanager.CreateAsync(user, registerDto.Password);
                if(createdUser.Succeeded)
                {
                    var roleResult = await _usermanager.AddToRoleAsync(user, "User");
                    if(roleResult.Succeeded)
                    {
                        var token = await _tokenService.CreateToken(user);
                        return Ok(
                            new NewUserDto
                            {
                                Username = user.UserName,
                                Email = user.Email,
                                Token = token.ToString()
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                
                return StatusCode(500, e);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _usermanager.FindByNameAsync(loginDto.Username);
            if(user == null)
            {
                return Unauthorized("Invalid username");
            }
            var result = await _usermanager.CheckPasswordAsync(user, loginDto.Password);
            if(!result)
            {
                return Unauthorized("Invalid username or password");
            }
            var token = await _tokenService.CreateToken(user);
            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = token.ToString()
                }
            );
        }
    }

}