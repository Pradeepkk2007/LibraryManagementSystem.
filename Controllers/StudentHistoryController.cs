using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    
    
        [Authorize(Roles ="Admin,Librarian")]
        [ApiController]
        [Route("api/[controller]")]
        public class StudentHistoryController : ControllerBase
        {
            private readonly IStudentHistoryService _studentHistoryService;

            public StudentHistoryController(IStudentHistoryService studentHistoryService)
            {
                _studentHistoryService = studentHistoryService;
            }

            [HttpGet("{studentId}")]
            public IActionResult GetStudentHistory(int studentId)
            {
                var history = _studentHistoryService.GetStudentHistory(studentId);
                return Ok(history);
            }
        }
    }

