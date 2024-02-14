using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSLearn.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Reply_To_Answer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_topic_Replys_ReplyId",
                table: "tb_topic");

            migrationBuilder.RenameColumn(
                name: "ReplyId",
                table: "tb_topic",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_topic_ReplyId",
                table: "tb_topic",
                newName: "IX_tb_topic_AnswerId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2fb379ec-c882-44e4-a8b0-771245c4eb49", "9124b41b-5a49-4b2a-a017-45228ed2271c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "163169ea-10bb-4fc3-ab49-3cd084bb5a7a", "e91e8327-b6aa-494a-add3-6bbe51dde12d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a52fb53-515f-42ee-8afd-a8331873213b", "921d386b-c109-4054-b24b-3ce0d0f6bdb6" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_topic_Replys_AnswerId",
                table: "tb_topic",
                column: "AnswerId",
                principalTable: "Replys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_topic_Replys_AnswerId",
                table: "tb_topic");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "tb_topic",
                newName: "ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_topic_AnswerId",
                table: "tb_topic",
                newName: "IX_tb_topic_ReplyId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_tb_topic_Replys_ReplyId",
                table: "tb_topic",
                column: "ReplyId",
                principalTable: "Replys",
                principalColumn: "Id");
        }
    }
}
