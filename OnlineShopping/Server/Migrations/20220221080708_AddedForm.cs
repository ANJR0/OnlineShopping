using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Server.Migrations
{
    public partial class AddedForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "c4a6fc34-bea9-46ea-bea4-c0e8ee7f0f43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "6fe8e9cc-9281-45b7-abed-738c5f929466");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccb383e5-6d11-4a31-bb4b-98a6abebd415", "AQAAAAEAACcQAAAAEG+fwd/pGPJjFahefVViYgNBBLlruSVBePaJaxlf4b3pGAMRyD3VXPsoNZeJwx1AUg==", "aa14f40d-ab97-488b-92c9-82f422691145" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                column: "ConcurrencyStamp",
                value: "6466dd16-cecd-4b5a-a896-6c9909ee60dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                column: "ConcurrencyStamp",
                value: "a3bbe24c-6a5d-4aa7-b806-171a090bc96e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cc993a0-8c21-445b-ba79-5d127d00daf2", "AQAAAAEAACcQAAAAEM8CMMrhyKdfE9PV7V/0g3BBRphJB2HTg0yRO0UFOK7JHrm9d0gtCOrX/j9Y+B/dcQ==", "369a929c-7e09-40e6-9a43-2866e4011ef3" });
        }
    }
}
