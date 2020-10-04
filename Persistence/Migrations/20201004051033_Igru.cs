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
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Strains");
        }
    }
}
