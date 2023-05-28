using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notificacion.Migrations
{
    public partial class tablenotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54746dbf-3e9a-4db9-88aa-eab1b6a255a0", "7ea34cbb-3eab-44a7-bcfb-fea95106bea8", "employed", "EMPLOYED" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a0b5be1-2395-44a4-8a09-7bccabdc0c6b", "bbfbab28-0433-476b-b795-a4fb6bac17a2", "support", "SUPPORT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95b1163e-5693-45ee-b4f6-9cd836727979", "21d0ca81-05fe-4f0b-8b13-5dd6d41a6d03", "admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54746dbf-3e9a-4db9-88aa-eab1b6a255a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a0b5be1-2395-44a4-8a09-7bccabdc0c6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95b1163e-5693-45ee-b4f6-9cd836727979");

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
    }
}
