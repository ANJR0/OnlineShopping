using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Server.Migrations
{
    public partial class AddForm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "d89491f6-f41a-49c9-9eb6-9418f3be451c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "ce403cb5-53db-4f70-a48f-879320559c54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d433b799-1b5b-43bb-81ed-5c2c49e24b8a", "AQAAAAEAACcQAAAAEPQbfx7kMHvixwg2wgEwdWncUkt9SYa1UcEqf1ShN+ZV6dGAGMNK6uZL/4ChPP9DCw==", "f1145a1f-e8e3-4e2a-85f6-1bafaaff0406" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "d7ae7bb1-5ff4-487a-8556-676697e015ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "cb0d0df8-25c2-44d9-bb4c-3a6565476e0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2a59b44-f8d9-4dd9-a11a-eedbd5bb05b1", "AQAAAAEAACcQAAAAEH0Lo89fP7sDyc4iaTburVzVtY6J7y07l6gCfloNxVyPd4l1SLY/r+RClKzy/dcYDg==", "0c81f076-1d5d-4187-8b37-7086616d5b53" });
        }
    }
}
