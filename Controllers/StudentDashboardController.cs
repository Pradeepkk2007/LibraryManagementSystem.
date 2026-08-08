using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin,Librarian")]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentDashboardController : ControllerBase
    {
        private readonly IStudentDashboardService _studentDashboardService;

        public StudentDashboardController(IStudentDashboardService studentDashboardService)
        {
            _studentDashboardService = studentDashboardService;
        }

        [HttpGet("{studentId}")]
        public IActionResult GetStudentDashboard(int studentId)
        {
            var dashboard = _studentDashboardService.GetStudentDashboard(studentId);

            return Ok(dashboard);
        }
    }
}