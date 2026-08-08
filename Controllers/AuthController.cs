using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var message = _authService.Register(registerDto);
            return Ok(message);
        }

        
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _authService.Login(loginDto);
            return Ok(result);
        }
    }
}
