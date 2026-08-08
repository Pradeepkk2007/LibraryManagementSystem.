using LibraryManagementSystem.API.DTOs.Publisher;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IPublisherService
    {
        List<PublisherDto> GetAllPublishers();

        PublisherDto GetPublisherById(int publisherId);

        string CreatePublisher(CreatePublisherDto createPublisherDto);

        string UpdatePublisher(int publisherId, UpdatePublisherDto updatePublisherDto);

        string DeletePublisher(int publisherId);
    }
}