using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbolaApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyTemperature = table.Column<double>(type: "float", nullable: false),
                    IsSevere = table.Column<bool>(type: "bit", nullable: false),
                    ProlongedHighFever = table.Column<bool>(type: "bit", nullable: false),
                    FrequentHeadache = table.Column<bool>(type: "bit", nullable: false),
                    AbdominalStomachPain = table.Column<bool>(type: "bit", nullable: false),
                    Vomiting = table.Column<bool>(type: "bit", nullable: false),
                    Nausea = table.Column<bool>(type: "bit", nullable: false),
                    Diarrhea = table.Column<bool>(type: "bit", nullable: false),
                    SoreThroat = table.Column<bool>(type: "bit", nullable: false),
                    Lethargy = table.Column<bool>(type: "bit", nullable: false),
                    ChestPain = table.Column<bool>(type: "bit", nullable: false),
                    Weakness = table.Column<bool>(type: "bit", nullable: false),
                    Dehydration = table.Column<bool>(type: "bit", nullable: false),
                    RedEyes = table.Column<bool>(type: "bit", nullable: false),
                    LackOfAppetite = table.Column<bool>(type: "bit", nullable: false),
                    DifficultyInBreathing = table.Column<bool>(type: "bit", nullable: false),
                    InternalExternalBleeding = table.Column<bool>(type: "bit", nullable: false),
                    SkinTexture = table.Column<bool>(type: "bit", nullable: false),
                    HighFever = table.Column<bool>(type: "bit", nullable: false),
                    SevereHeadache = table.Column<bool>(type: "bit", nullable: false),
                    MuscleAchesAndPains = table.Column<bool>(type: "bit", nullable: false),
                    SevereMalaise = table.Column<bool>(type: "bit", nullable: false),
                    SevereWateryDiarrhea = table.Column<bool>(type: "bit", nullable: false),
                    AbdominalPainAndCramping = table.Column<bool>(type: "bit", nullable: false),
                    DeepSetEyes = table.Column<bool>(type: "bit", nullable: false),
                    ExpressionlessFaces = table.Column<bool>(type: "bit", nullable: false),
                    ExtremeLethargy = table.Column<bool>(type: "bit", nullable: false),
                    NonitchyRash = table.Column<bool>(type: "bit", nullable: false),
                    MultipleBleeding = table.Column<bool>(type: "bit", nullable: false),
                    IrritabilityAndAggression = table.Column<bool>(type: "bit", nullable: false),
                    Orchitis = table.Column<bool>(type: "bit", nullable: false),
                    SevereBloodLossAndShock = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predictions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_UserId",
                table: "MedicalRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_UserId",
                table: "Predictions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
