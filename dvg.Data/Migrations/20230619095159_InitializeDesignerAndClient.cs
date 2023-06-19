using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dvg.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDesignerAndClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreateDate", "FirstName", "LastName", "PhoneNumber", "ProjectId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("049f949d-f3a5-4a16-b854-03adea220030"), new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(453), "Alex", "Freeman", "+380939876532", null, null },
                    { new Guid("feb28f61-1c23-4d90-aeae-ce1e2f9b410f"), new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(460), "Igor", "Kowalski", "+380631234567", null, null }
                });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "Id", "CreateDate", "CustomTaskId", "FirstName", "LastName", "PhoneNumber", "Position", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("979f3bef-38be-4bf7-8d6b-19416b272264"), new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(448), null, "Valeria", "Wayne", "+380661003040", 2, null },
                    { new Guid("bb9b41ca-3134-4f9d-b70c-53527f4b7df4"), new DateTime(2023, 6, 19, 12, 51, 59, 541, DateTimeKind.Local).AddTicks(412), null, "Kate", "Ivanka", "+380991002030", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("049f949d-f3a5-4a16-b854-03adea220030"));

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("feb28f61-1c23-4d90-aeae-ce1e2f9b410f"));

            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: new Guid("979f3bef-38be-4bf7-8d6b-19416b272264"));

            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "Id",
                keyValue: new Guid("bb9b41ca-3134-4f9d-b70c-53527f4b7df4"));
        }
    }
}
