using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.WebAPI.Migrations
{
    public partial class added_AppUser_And_Seed_Datas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 4, 23, 49, 53, 630, DateTimeKind.Local).AddTicks(1459), "$2a$11$GwfnusyB2ow46jsG4uCe4umj5UeBbR3gx5hkIvdVSePQuCvMjCv2W" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 4, 23, 49, 53, 630, DateTimeKind.Local).AddTicks(1475), "$2a$11$1xftmrBYO2xIJImyjtGS..oux8tSzqIyhREOU5GyEw494yzi2QJWC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 4, 23, 48, 7, 917, DateTimeKind.Local).AddTicks(832), "$2a$11$81BCfxJZD/VUjQMOgNBIzOtFcmCUM7B30W5Fg/xZ4x/KV3Ka2oeSC" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2023, 1, 4, 23, 48, 7, 917, DateTimeKind.Local).AddTicks(849), "$2a$11$qn/FZPzDfnU1hJ9/T49mOu46kRoDqoJYonAhTvjBHzRxPCUcrfPli" });
        }
    }
}
