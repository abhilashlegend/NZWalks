using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2638289f-5e00-4a48-8b6b-bb6aae5db7c3"), "Easy" },
                    { new Guid("41c304a8-b65b-404f-8691-811ff1892495"), "Hard" },
                    { new Guid("9cda2b73-d689-4e15-8e1a-782327899929"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("7bfa23c7-df03-467c-b30b-b1e4b6e68d7d"), "KA", "KARNATAKA", "images/karnataka.jpeg" },
                    { new Guid("b202bec4-5586-460d-b33a-7546a8506eef"), "AP", "ANDRA PRADESH", "images/andra.jpeg" },
                    { new Guid("dbd0bbf0-0565-42b2-ab6b-d6fc46d5bb5c"), "TN", "TAMIL NADU", "images/tamilnadu.jpeg" },
                    { new Guid("fd45ffca-996b-47d1-9635-b7747303c0d8"), "KE", "KERALA", "images/kerala.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2638289f-5e00-4a48-8b6b-bb6aae5db7c3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("41c304a8-b65b-404f-8691-811ff1892495"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9cda2b73-d689-4e15-8e1a-782327899929"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7bfa23c7-df03-467c-b30b-b1e4b6e68d7d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b202bec4-5586-460d-b33a-7546a8506eef"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dbd0bbf0-0565-42b2-ab6b-d6fc46d5bb5c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fd45ffca-996b-47d1-9635-b7747303c0d8"));
        }
    }
}
