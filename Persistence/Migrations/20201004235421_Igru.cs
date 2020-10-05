using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Igru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GardenEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GardenId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    Humidity = table.Column<double>(nullable: false),
                    LightLevel = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    GrowType = table.Column<string>(nullable: true),
                    GrowSize = table.Column<string>(nullable: true),
                    GrowStyle = table.Column<string>(nullable: true),
                    ContainerSize = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutrientRecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    PH = table.Column<string>(nullable: true),
                    MixTime = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientRecipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PlantId = table.Column<Guid>(nullable: false),
                    NutrientRecipeId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    SoilSaturation = table.Column<double>(nullable: false),
                    PH = table.Column<double>(nullable: false),
                    Height = table.Column<string>(nullable: true),
                    BudTrichomeColor = table.Column<string>(nullable: true),
                    GrowState = table.Column<string>(nullable: true),
                    ColaSize = table.Column<string>(nullable: true),
                    AverageBudSize = table.Column<string>(nullable: true),
                    StalkDiameter = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GardenId = table.Column<Guid>(nullable: false),
                    StrainId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    GrowCycleLength = table.Column<string>(nullable: true),
                    Aquired = table.Column<DateTime>(nullable: false),
                    Parentage = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DaysFlowering = table.Column<double>(nullable: false),
                    DaysCured = table.Column<double>(nullable: false),
                    HarvestedWeight = table.Column<string>(nullable: true),
                    BudDensity = table.Column<double>(nullable: false),
                    BudPistils = table.Column<bool>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Aquired = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ThcPercentage = table.Column<double>(nullable: false),
                    CbdPercentage = table.Column<double>(nullable: false),
                    Parentage = table.Column<string>(nullable: true),
                    Aroma = table.Column<string>(nullable: true),
                    Taste = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Owner = table.Column<Guid>(nullable: false),
                    Editors = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GardenEntries");

            migrationBuilder.DropTable(
                name: "Gardens");

            migrationBuilder.DropTable(
                name: "NutrientRecipes");

            migrationBuilder.DropTable(
                name: "PlantEntries");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Strains");
        }
    }
}
