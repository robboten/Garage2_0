﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage20.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDb",
                columns: table => new
                {
                    TypeDbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDb", x => x.TypeDbId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationNr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    BrandDbId = table.Column<int>(type: "int", nullable: false),
                    Wheels = table.Column<int>(type: "int", nullable: false),
                    TypeDbId = table.Column<int>(type: "int", nullable: false, defaultValue:3),
                    Model = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_BrandDb_BrandDbId",
                        column: x => x.BrandDbId,
                        principalTable: "BrandDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_TypeDb_TypeDbId",
                        column: x => x.TypeDbId,
                        principalTable: "TypeDb",
                        principalColumn: "TypeDbId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BrandDbId",
                table: "Vehicle",
                column: "BrandDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TypeDbId",
                table: "Vehicle",
                column: "TypeDbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "BrandDb");

            migrationBuilder.DropTable(
                name: "TypeDb");
        }
    }
}
