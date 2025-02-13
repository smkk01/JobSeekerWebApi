using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersWebApi.Migrations
{
    /// <inheritdoc />
    public partial class updateddb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences");

            migrationBuilder.DropIndex(
                name: "IX_SoftwareExperiences_ApplicantId",
                table: "SoftwareExperiences");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SoftwareExperiences",
                table: "SoftwareExperiences");

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

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareExperiences_ApplicantId",
                table: "SoftwareExperiences",
                column: "ApplicantId");
        }
    }
}
