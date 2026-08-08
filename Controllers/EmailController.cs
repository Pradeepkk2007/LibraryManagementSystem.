using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("Test")]
        public async Task<IActionResult> TestEmail()
        {
            await _emailService.SendEmailAsync(
                "YOUR_EMAIL@gmail.com",
                "Test Email",
                "<h2>Email Service Working Successfully!</h2><p>Your Library Management System can now send emails.</p>");

            return Ok("Email sent successfully.");
        }
    }
}