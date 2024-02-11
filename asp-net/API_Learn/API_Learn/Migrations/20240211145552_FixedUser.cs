using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSLearn.Migrations
{
    /// <inheritdoc />
    public partial class FixedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b82acd4f-2cc2-4a0c-8846-077d47a5c6b6", "68a3f01f-17bc-4033-b955-330be6a27abf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f39f4a1-1b6e-413e-aa16-c31490a5f321", "40adcd14-bf65-4691-8338-c6fc7ceccd59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "deb1f14e-7ea7-46c6-b92f-dab6094b1821", "9fbfffb0-f47c-419d-9cb7-fd004d24c990" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e232e65c-6eaf-4bec-a670-03f79bdae734", "9495a870-3954-443c-a81e-b2ac3752bd7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76d7e625-f131-44d2-b4ed-ee813f94fb23", "5376244a-3a4c-42bc-98cc-199c06dbd64c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "39a4c971-c582-4747-953c-c04259324c79", "b1703405-4fce-4b02-96e2-e71a5a92781f" });
        }
    }
}
