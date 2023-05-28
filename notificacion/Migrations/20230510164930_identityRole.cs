using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notificacion.Migrations
{
    public partial class identityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5df05031-f2a2-4f02-af34-841933258c5e", "8b861812-fa62-474c-b53e-3cc814afcf67", "support", "SUPPORT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "725d24be-8ed5-4a1e-8acc-8f3b50d07a4f", "13805d9f-e566-4bd3-bbd4-c29fb1d2c4d1", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cca49020-74ee-42e2-810c-561a7864fc53", "3a3d6c19-1649-4dd6-8b2b-80b17d9f964c", "employed", "EMPLOYED" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5df05031-f2a2-4f02-af34-841933258c5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "725d24be-8ed5-4a1e-8acc-8f3b50d07a4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca49020-74ee-42e2-810c-561a7864fc53");
        }
    }
}
