using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorWasmApp1.Server.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d5a86e-c6d8-4b72-b8d8-722d8473313e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb541996-5882-4fb4-99fb-8b7e019a2b36");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "305babf9-bd58-46b7-aec5-d40425ad28b7", "5334816e-0f05-4f68-b37a-d6d1c3edbf3c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7a8d830-7080-4250-ac96-14d8af415521", "961cf6f4-f3f6-4f4c-849f-7dfe97463f3e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "305babf9-bd58-46b7-aec5-d40425ad28b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7a8d830-7080-4250-ac96-14d8af415521");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb541996-5882-4fb4-99fb-8b7e019a2b36", "8ebc13d8-ab37-4884-9902-149b09d1cc29", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d5a86e-c6d8-4b72-b8d8-722d8473313e", "59cd4e15-2df7-4cad-975a-51fbff0cc89c", "Admin", "ADMIN" });
        }
    }
}
