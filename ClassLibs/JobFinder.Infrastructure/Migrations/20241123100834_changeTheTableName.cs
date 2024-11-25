using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeTheTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillId");

            migrationBuilder.CreateTable(
                name: "SkillIds",
                columns: table => new
                {
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillIds", x => new { x.ResumeId, x.ResumeUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_SkillIds_Resumes_ResumeId_ResumeUserId",
                        columns: x => new { x.ResumeId, x.ResumeUserId },
                        principalTable: "Resumes",
                        principalColumns: new[] { "ResumeId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillIds");

            migrationBuilder.CreateTable(
                name: "SkillId",
                columns: table => new
                {
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillId", x => new { x.ResumeId, x.ResumeUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_SkillId_Resumes_ResumeId_ResumeUserId",
                        columns: x => new { x.ResumeId, x.ResumeUserId },
                        principalTable: "Resumes",
                        principalColumns: new[] { "ResumeId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
