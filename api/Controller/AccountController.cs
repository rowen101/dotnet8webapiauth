using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManger;
        public AccountController(UserManager<AppUser> UserManager)
        {
            _userManger = UserManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterDto registerDto)
        {
            try{
                if(!ModelState.IsValid)
                return BadRequest(ModelState);

                var AppUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                var createUser = await _userManger.CreateAsync(AppUser, registerDto.Password);

                if(createUser.Succeeded)
                {
                    var roleResult = await _userManger.AddToRoleAsync(AppUser,"User");
                    if(roleResult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }

            }
            catch(Exception e)
            {
                return StatusCode(500,e);
            }
        }
    }
}