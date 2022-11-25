using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NordicDoorTestingrep.Migrations
{
    public partial class testestest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Suggestion",
                columns: table => new
                {
                    SuggestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    SugCreatorID = table.Column<int>(type: "int", nullable: false),
                    ResponsibleEmployeeID = table.Column<int>(type: "int", nullable: false),
                    SugDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SugCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JDISug = table.Column<bool>(type: "bit", nullable: false),
                    progress = table.Column<float>(type: "real", nullable: false),
                    SugStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOrDueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestion", x => x.SuggestionId);
                    table.ForeignKey(
                        name: "FK_Suggestion_Employee_ResponsibleEmployeeID",
                        column: x => x.ResponsibleEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestion_Employee_SugCreatorID",
                        column: x => x.SugCreatorID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Suggestion_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembership_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembership_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SugID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comment_Suggestion_SugID",
                        column: x => x.SugID,
                        principalTable: "Suggestion",
                        principalColumn: "SuggestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SugImage",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SugID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugImage", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_SugImage_Suggestion_SugID",
                        column: x => x.SugID,
                        principalTable: "Suggestion",
                        principalColumn: "SuggestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_EmployeeID",
                table: "Comment",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SugID",
                table: "Comment",
                column: "SugID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_ResponsibleEmployeeID",
                table: "Suggestion",
                column: "ResponsibleEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_SugCreatorID",
                table: "Suggestion",
                column: "SugCreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_TeamID",
                table: "Suggestion",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_SugImage_SugID",
                table: "SugImage",
                column: "SugID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembership_EmployeeID",
                table: "TeamMembership",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembership_TeamID",
                table: "TeamMembership",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "SugImage");

            migrationBuilder.DropTable(
                name: "TeamMembership");

            migrationBuilder.DropTable(
                name: "Suggestion");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
