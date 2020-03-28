using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class AddStakeholderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stakeholder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    ProducerType = table.Column<int>(nullable: false),
                    BuyerType = table.Column<int>(nullable: false),
                    Organization = table.Column<string>(maxLength: 255, nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    Country = table.Column<string>(maxLength: 255, nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Equipment = table.Column<string>(nullable: true),
                    HowCanYouHelp = table.Column<string>(nullable: true),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholder_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholder_IdentityUserId",
                table: "Stakeholder",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stakeholder");
        }
    }
}
