using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addLocalUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SoftwareExperiences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SoftwareExperiences",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LocalUsers",
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
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareExperiences_ApplicantId",
                table: "SoftwareExperiences",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareExperiences_ApplicantId",
                table: "SoftwareExperiences");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "SoftwareExperiences",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SoftwareExperiences",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences",
                columns: new[] { "ApplicantId", "SoftwareId" });
        }
    }
}
