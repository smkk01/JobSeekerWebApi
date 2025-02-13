﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomersWebApi.Migrations
{
    /// <inheritdoc />
    public partial class addsoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoftwareExperiences_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoftwareExperiences_Softwares_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Softwares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareExperiences_ApplicantId",
                table: "SoftwareExperiences",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareExperiences_SoftwareId",
                table: "SoftwareExperiences",
                column: "SoftwareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwareExperiences");

            migrationBuilder.DropTable(
                name: "Softwares");
        }
    }
}
