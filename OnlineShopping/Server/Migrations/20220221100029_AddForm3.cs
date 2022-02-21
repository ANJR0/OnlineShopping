using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Server.Migrations
{
    public partial class AddForm3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "d581ec06-829c-45c9-a75d-9be186681b4a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "436e3fd3-c13b-4bcb-84ea-b0323ae35c0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09d36c34-d9eb-4138-a9b6-25ce49d36abb", "AQAAAAEAACcQAAAAECzrK/o5XLsAH2tvelZPJ0u6i/kgN9NguYMNWgQk5cGzptPr4Q+B/3sxqqZA8H5rBA==", "e7c8afe2-ae8d-4df5-99fc-339019f6e535" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
