using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    internal class insertadta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            // Seed Subjects table
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
            { 1, "Science books", "Science" },
            { 2, "Literature books", "Literature" },
            { 3, "History books", "History" }
                });

            // Seed user table
            migrationBuilder.InsertData(
                table: "user",
                columns: new[]
                {
            "Id", "FirstName", "LastName", "NationalID", "Picture", "UserName", "NormalizedUserName", "Email",
            "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber",
            "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
                },
                values: new object[,]
                {
            { "1", "John", "Doe", "123456789", "john.jpg", "johndoe", "JOHNDOE", "john@example.com",
              "JOHN@EXAMPLE.COM", true, "hashed_password1", "stamp1", "conc1", "555-1234",
              true, false, null, true, 0 },

            { "2", "Alice", "Smith", "987654321", "alice.jpg", "alicesmith", "ALICESMITH", "alice@example.com",
              "ALICE@EXAMPLE.COM", false, "hashed_password2", "stamp2", "conc2", "555-5678",
              false, true, null, false, 1 }
                });

            // Seed Authors table
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "WebSite", "UserId" },
                values: new object[,]
                {
            { 1, "http://johndoe.com", "1" },
            { 2, "http://alicesmith.com", "2" }
                });

            // Seed Publishers table
            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "WebSite", "UserId" },
                values: new object[,]
                {
            { 1, "http://sciencebooks.com", "1" },
            { 2, "http://literaturebooks.com", "2" }
                });

            // Seed Books table
            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "Isbn", "Notes", "PageCount", "Price", "PublicationDate", "Summary", "Title", "SubjectId", "PublisherId" },
                values: new object[,]
                {
            { 1, "978-3-16-148410-0", "Great book on science", 250, 29.99m, new DateTime(2023, 6, 1), "A detailed exploration of modern science.", "Science Explained", 1, 1 },
            { 2, "978-1-23-456789-7", "A masterpiece of literature", 320, 19.99m, new DateTime(2021, 10, 15), "A classic work of literature.", "Literature Masterpiece", 2, 2 }
                });

            // Seed Author-Book relations (AutherBook table)
            migrationBuilder.InsertData(
                table: "AutherBook",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
            { 1, 1 },
            { 2, 2 }
                });

            // Seed Book Attachments table
            migrationBuilder.InsertData(
                table: "bookAttachment",
                columns: new[] { "ID", "Path", "BookId" },
                values: new object[,]
                {
            { 1, "path/to/science-attachment.pdf", 1 },
            { 2, "path/to/literature-attachment.pdf", 2 }
                });
        }
    

    }
}
