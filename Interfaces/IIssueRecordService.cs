using LibraryManagementSystem.API.DTOs;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IIssueRecordService
    {
        List<IssueRecordDto> GetAllIssueRecords();

        IssueRecordDto? GetIssueRecordById(int issueId);

        IssueRecordDto? IssueBook(CreateIssueRecordDto createIssueRecordDto);

        IssueRecordDto? ReturnBook(int issueId, UpdateIssueRecordDto updateIssueRecordDto);
    }
}