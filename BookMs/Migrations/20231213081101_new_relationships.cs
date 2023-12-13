using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMs.Migrations
{
    /// <inheritdoc />
    public partial class new_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BooksId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Authors");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId1",
                table: "Books",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId1",
                table: "Books",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId1",
                table: "Books",
                column: "AuthorId1",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "BooksId",
                table: "Authors",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BooksId",
                table: "Authors",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BooksId",
                table: "Authors",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
