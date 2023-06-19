using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dvg.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(300)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(300)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Term = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomTask_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(300)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(300)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CustomTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designers_CustomTask_CustomTaskId",
                        column: x => x.CustomTaskId,
                        principalTable: "CustomTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DesignerProject",
                columns: table => new
                {
                    AttendeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignerProject", x => new { x.AttendeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_DesignerProject_Designers_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "Designers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignerProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ProjectId",
                table: "Clients",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTask_ProjectId",
                table: "CustomTask",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignerProject_ProjectsId",
                table: "DesignerProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Designers_CustomTaskId",
                table: "Designers",
                column: "CustomTaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DesignerProject");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "CustomTask");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
