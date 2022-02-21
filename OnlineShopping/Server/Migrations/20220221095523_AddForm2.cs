using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Server.Migrations
{
    public partial class AddForm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "21e33344-dbfa-4e41-bd34-53d390630b46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "6e895279-7db5-4f82-a264-1290bce9b178");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4891aca3-a9dc-4dd6-af3a-fdb785d67229", "AQAAAAEAACcQAAAAEKLJlk7prh2LNc55k+NZ2L7IpIh6bQUfD9deDQVHryv9cs4bxY6NsohXohNtbiX+zQ==", "78c5b11b-8c5f-4963-b60a-9c12e336888c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
