using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsemkaVote.API.Migrations
{
    /// <inheritdoc />
    public partial class InitializeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    division = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VotingHeaders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingHeaders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VotingCandidates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    votingHeaderId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingCandidates", x => x.id);
                    table.ForeignKey(
                        name: "FK_VotingCandidates_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VotingCandidates_VotingHeaders_votingHeaderId",
                        column: x => x.votingHeaderId,
                        principalTable: "VotingHeaders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    votingCandidateId = table.Column<int>(type: "int", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_VotingDetails_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VotingDetails_VotingCandidates_votingCandidateId",
                        column: x => x.votingCandidateId,
                        principalTable: "VotingCandidates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotingCandidates_employeeId",
                table: "VotingCandidates",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingCandidates_votingHeaderId",
                table: "VotingCandidates",
                column: "votingHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingDetails_employeeId",
                table: "VotingDetails",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingDetails_votingCandidateId",
                table: "VotingDetails",
                column: "votingCandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotingDetails");

            migrationBuilder.DropTable(
                name: "VotingCandidates");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "VotingHeaders");
        }
    }
}
