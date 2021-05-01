﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffAndThings.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    JsonObject = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    JsonObject = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FriendlyCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    OrderPesonId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderModel_UserModel_OrderPesonId",
                        column: x => x.OrderPesonId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FriendlyCode = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    OrderPersonId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_OrderPersonId",
                        column: x => x.OrderPersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkuModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    OrderModelId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkuModel_OrderModel_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "OrderModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    OrderEntityId = table.Column<Guid>(nullable: true),
                    ProductEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skus_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skus_Products_ProductEntityId",
                        column: x => x.ProductEntityId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    SellerId = table.Column<Guid>(nullable: false),
                    SkuId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Skus_SkuId",
                        column: x => x.SkuId,
                        principalTable: "Skus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_OrderPesonId",
                table: "OrderModel",
                column: "OrderPesonId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderPersonId",
                table: "Orders",
                column: "OrderPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuModel_OrderModelId",
                table: "SkuModel",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Skus_OrderEntityId",
                table: "Skus",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skus_ProductEntityId",
                table: "Skus",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SellerId",
                table: "Stocks",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SkuId",
                table: "Stocks",
                column: "SkuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogModel");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "SkuModel");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "Skus");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
