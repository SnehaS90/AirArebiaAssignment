namespace Test.Controllers;

using Microsoft.AspNetCore.Mvc;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Services;

[ApiController]
[Route("api/user")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);       

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        return Ok(response);
    }  
   
}
