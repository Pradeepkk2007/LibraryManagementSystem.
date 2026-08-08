using LibraryManagementSystem.API.DTOs.Publisher;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllPublishers()
        {
            var publishers = _publisherService.GetAllPublishers();

            return Ok(publishers);
        }

        [HttpGet("{publisherId}")]
        [Authorize]
        public IActionResult GetPublisherById(int publisherId)
        {
            var publisher = _publisherService.GetPublisherById(publisherId);

            return Ok(publisher);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult CreatePublisher(CreatePublisherDto createPublisherDto)
        {
            var message = _publisherService.CreatePublisher(createPublisherDto);

            return Ok(message);
        }

        [HttpPut("{publisherId}")]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult UpdatePublisher(int publisherId, UpdatePublisherDto updatePublisherDto)
        {
            var message = _publisherService.UpdatePublisher(publisherId, updatePublisherDto);

            return Ok(message);
        }

        [HttpDelete("{publisherId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePublisher(int publisherId)
        {
            var message = _publisherService.DeletePublisher(publisherId);

            return Ok(message);
        }
    }
}