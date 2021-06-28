using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Test.Data.Migrations
{
    public partial class BookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Bookings_BookingId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Bookings_BookingId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "DriverVM");

            migrationBuilder.DropTable(
                name: "CarVM");

            migrationBuilder.DropTable(
                name: "BookingVM");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_BookingId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_BookingId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Cars");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPaid",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Drivers_DriverId",
                table: "Bookings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Drivers_DriverId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsPaid",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "BookingVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ToAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingVMId = table.Column<int>(type: "int", nullable: true),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    MakeYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarVM_BookingVM_BookingVMId",
                        column: x => x.BookingVMId,
                        principalTable: "BookingVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingVMId = table.Column<int>(type: "int", nullable: true),
                    CarVMId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverVM_BookingVM_BookingVMId",
                        column: x => x.BookingVMId,
                        principalTable: "BookingVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriverVM_CarVM_CarVMId",
                        column: x => x.CarVMId,
                        principalTable: "CarVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_BookingId",
                table: "Drivers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BookingId",
                table: "Cars",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CarVM_BookingVMId",
                table: "CarVM",
                column: "BookingVMId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVM_BookingVMId",
                table: "DriverVM",
                column: "BookingVMId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVM_CarVMId",
                table: "DriverVM",
                column: "CarVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Bookings_BookingId",
                table: "Cars",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Bookings_BookingId",
                table: "Drivers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
