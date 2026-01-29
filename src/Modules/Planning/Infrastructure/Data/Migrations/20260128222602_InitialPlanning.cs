using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planning.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialPlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "planning");

            migrationBuilder.CreateTable(
                name: "Setlists",
                schema: "planning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AccessCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetlistItems",
                schema: "planning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SetlistId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderIndex = table.Column<int>(type: "integer", nullable: false),
                    PerformanceNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetlistItems_Setlists_SetlistId",
                        column: x => x.SetlistId,
                        principalSchema: "planning",
                        principalTable: "Setlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetlistItems_SetlistId",
                schema: "planning",
                table: "SetlistItems",
                column: "SetlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Setlists_AccessCode",
                schema: "planning",
                table: "Setlists",
                column: "AccessCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetlistItems",
                schema: "planning");

            migrationBuilder.DropTable(
                name: "Setlists",
                schema: "planning");
        }
    }
}
