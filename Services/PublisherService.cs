using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs.Publisher;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PublisherDto> GetAllPublishers()
        {
            return _context.Publishers
                           .Select(publisher => new PublisherDto
                           {
                               PublisherId = publisher.PublisherId,
                               PublisherName = publisher.PublisherName,
                               Address = publisher.Address,
                               Phone = publisher.Phone,
                               Email = publisher.Email,
                               Website = publisher.Website
                           })
                           .ToList();
        }

        public PublisherDto GetPublisherById(int publisherId)
        {
            var publisher = _context.Publishers
                                    .FirstOrDefault(x => x.PublisherId == publisherId);

            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }

            return new PublisherDto
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                Address = publisher.Address,
                Phone = publisher.Phone,
                Email = publisher.Email,
                Website = publisher.Website
            };
        }

        public string CreatePublisher(CreatePublisherDto createPublisherDto)
        {
            bool publisherExists = _context.Publishers.Any(x =>
                x.PublisherName == createPublisherDto.PublisherName);

            if (publisherExists)
            {
                throw new BadRequestException("Publisher already exists.");
            }

            var publisher = new Publisher
            {
                PublisherName = createPublisherDto.PublisherName,
                Address = createPublisherDto.Address,
                Phone = createPublisherDto.Phone,
                Email = createPublisherDto.Email,
                Website = createPublisherDto.Website,
                CreatedAt = DateTime.UtcNow
            };

            _context.Publishers.Add(publisher);

            _context.SaveChanges();

            return "Publisher created successfully.";
        }

        public string UpdatePublisher(int publisherId, UpdatePublisherDto updatePublisherDto)
        {
            var publisher = _context.Publishers
                                    .FirstOrDefault(x => x.PublisherId == publisherId);

            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }

            publisher.PublisherName = updatePublisherDto.PublisherName;
            publisher.Address = updatePublisherDto.Address;
            publisher.Phone = updatePublisherDto.Phone;
            publisher.Email = updatePublisherDto.Email;
            publisher.Website = updatePublisherDto.Website;
            publisher.UpdatedAt = DateTime.UtcNow;

            _context.SaveChanges();

            return "Publisher updated successfully.";
        }

        public string DeletePublisher(int publisherId)
        {
            var publisher = _context.Publishers
                                    .FirstOrDefault(x => x.PublisherId == publisherId);

            if (publisher == null)
            {
                throw new NotFoundException("Publisher not found.");
            }

            _context.Publishers.Remove(publisher);

            _context.SaveChanges();

            return "Publisher deleted successfully.";
        }
    }
}