using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class SyncDatabaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Book_BookId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Book_BookId1",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecords_BookCopies_CopyId",
                table: "IssueRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecords_Student_StudentId",
                table: "IssueRecords");

            migrationBuilder.DropIndex(
                name: "IX_BookCopies_BookId1",
                table: "BookCopies");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "BookCopies");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Book_BookId",
                table: "BookCopies",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecords_BookCopies_CopyId",
                table: "IssueRecords",
                column: "CopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecords_Student_StudentId",
                table: "IssueRecords",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopies_Book_BookId",
                table: "BookCopies");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecords_BookCopies_CopyId",
                table: "IssueRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueRecords_Student_StudentId",
                table: "IssueRecords");

            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "BookCopies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookId1",
                table: "BookCopies",
                column: "BookId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Book_BookId",
                table: "BookCopies",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopies_Book_BookId1",
                table: "BookCopies",
                column: "BookId1",
                principalTable: "Book",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecords_BookCopies_CopyId",
                table: "IssueRecords",
                column: "CopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueRecords_Student_StudentId", 
                table: "IssueRecords",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
