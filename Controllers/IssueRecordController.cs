using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IssueRecordController : ControllerBase
    {
        private readonly IIssueRecordService _issueRecordService;

        public IssueRecordController(IIssueRecordService issueRecordService)
        {
            _issueRecordService = issueRecordService;
        }


        [HttpGet]
        public IActionResult GetAllIssueRecords()
        {
            return Ok(_issueRecordService.GetAllIssueRecords());
        }

        [Authorize]
        [HttpGet("{issueId}")]
        public IActionResult GetIssueRecordById(int issueId)
        {
            var issueRecord = _issueRecordService.GetIssueRecordById(issueId);

            if (issueRecord == null)
            {
                return NotFound("Issue Record not found.");
            }

            return Ok(issueRecord);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost("IssueBook")]
        public IActionResult IssueBook(CreateIssueRecordDto createIssueRecordDto)
        {
            var issueRecord = _issueRecordService.IssueBook(createIssueRecordDto);

            if (issueRecord == null)
            {
                return BadRequest("Student not found, Book Copy not found or Book already issued.");
            }

            return Ok(issueRecord);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut("ReturnBook/{issueId}")]
        public IActionResult ReturnBook(int issueId, UpdateIssueRecordDto updateIssueRecordDto)
        {
            var issueRecord = _issueRecordService.ReturnBook(issueId, updateIssueRecordDto);

            if (issueRecord == null)
            {
                return BadRequest("Issue Record not found or Book already returned.");
            }

            return Ok(issueRecord);
        }
    }
}