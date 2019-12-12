using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLeasing.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "lessees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FixedPhone = table.Column<string>(maxLength: 20, nullable: true),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Neighborhood = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SquareMeters = table.Column<int>(nullable: false),
                    Rooms = table.Column<int>(nullable: false),
                    Stratum = table.Column<int>(nullable: false),
                    HasParkingLot = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    propertyTypeId = table.Column<int>(nullable: true),
                    ownerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_properties_Owners_ownerid",
                        column: x => x.ownerid,
                        principalTable: "Owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_properties_PropertyTypes_propertyTypeId",
                        column: x => x.propertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    propertyId = table.Column<int>(nullable: true),
                    lesseeId = table.Column<int>(nullable: true),
                    ownerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contracts_lessees_lesseeId",
                        column: x => x.lesseeId,
                        principalTable: "lessees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contracts_Owners_ownerid",
                        column: x => x.ownerid,
                        principalTable: "Owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contracts_properties_propertyId",
                        column: x => x.propertyId,
                        principalTable: "properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    propertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_properties_propertyId",
                        column: x => x.propertyId,
                        principalTable: "properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contracts_lesseeId",
                table: "contracts",
                column: "lesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_ownerid",
                table: "contracts",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_propertyId",
                table: "contracts",
                column: "propertyId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_ownerid",
                table: "properties",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_properties_propertyTypeId",
                table: "properties",
                column: "propertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_propertyId",
                table: "PropertyImages",
                column: "propertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "lessees");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owners",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
