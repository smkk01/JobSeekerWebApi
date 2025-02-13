using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersWebApi.Migrations
{
    /// <inheritdoc />
    public partial class adddbmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers");

            migrationBuilder.RenameTable(
                name: "LocalUsers",
                newName: "LocalUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalUser",
                table: "LocalUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LocalUser1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUser1", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalUser",
                table: "LocalUser");

            migrationBuilder.RenameTable(
                name: "LocalUser",
                newName: "LocalUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalUsers",
                table: "LocalUsers",
                column: "Id");
        }
    }
}
