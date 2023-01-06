using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations
{
    public partial class changed_AppUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 5, 3, 57, 46, 70, DateTimeKind.Local).AddTicks(7122), "admin123" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 5, 3, 57, 46, 70, DateTimeKind.Local).AddTicks(7131), "user123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 5, 0, 1, 5, 342, DateTimeKind.Local).AddTicks(6917), "$2a$11$IIQzxzpfGej7x/Vm5ZzGkO7pJavVzuCX30l9cRJo.g/7EN33WOntK" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 5, 0, 1, 5, 342, DateTimeKind.Local).AddTicks(6935), "$2a$11$Nq.NQIaNXJdO/8JoBqlq6ewVQIRrY/Tw/UpzNJbRYYgpUAL1EN7bO" });
        }
    }
}
