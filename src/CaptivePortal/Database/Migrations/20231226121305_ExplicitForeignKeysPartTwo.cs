﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaptivePortal.Database.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitForeignKeysPartTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceNetworks_DeviceNetworkId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceNetworkId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_DeviceNetworks_DeviceId",
                table: "DeviceNetworks");

            migrationBuilder.DropColumn(
                name: "DeviceNetworkId",
                table: "Devices");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceNetworks_DeviceId",
                table: "DeviceNetworks",
                column: "DeviceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeviceNetworks_DeviceId",
                table: "DeviceNetworks");

            migrationBuilder.AddColumn<int>(
                name: "DeviceNetworkId",
                table: "Devices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceNetworkId",
                table: "Devices",
                column: "DeviceNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceNetworks_DeviceId",
                table: "DeviceNetworks",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceNetworks_DeviceNetworkId",
                table: "Devices",
                column: "DeviceNetworkId",
                principalTable: "DeviceNetworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
