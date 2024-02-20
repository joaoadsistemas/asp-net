using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSLearn.Migrations
{
    /// <inheritdoc />
    public partial class UserReplyTopicManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Replys_ReplyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_topic_TopicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ReplyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TopicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ReplyUser",
                columns: table => new
                {
                    LikesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReplyLikesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyUser", x => new { x.LikesId, x.ReplyLikesId });
                    table.ForeignKey(
                        name: "FK_ReplyUser_AspNetUsers_LikesId",
                        column: x => x.LikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplyUser_Replys_ReplyLikesId",
                        column: x => x.ReplyLikesId,
                        principalTable: "Replys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    LikesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicLikesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.LikesId, x.TopicLikesId });
                    table.ForeignKey(
                        name: "FK_TopicUser_AspNetUsers_LikesId",
                        column: x => x.LikesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUser_tb_topic_TopicLikesId",
                        column: x => x.TopicLikesId,
                        principalTable: "tb_topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f640c0b5-f8d3-4e0a-8643-f5df72ab485e", "2cb5ded1-c58d-4f7f-9546-c30eba5a1c26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfad1ca1-e144-49c0-a5ad-82e2204422c4", "bd60dff2-ff9b-4b40-94a1-7df23484c0fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "896f8668-3189-4bfb-818d-d027704aa926", "0ee24c61-21af-4563-98f2-b674927ece7e" });

            migrationBuilder.CreateIndex(
                name: "IX_ReplyUser_ReplyLikesId",
                table: "ReplyUser",
                column: "ReplyLikesId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicUser_TopicLikesId",
                table: "TopicUser",
                column: "TopicLikesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplyUser");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385",
                columns: new[] { "ConcurrencyStamp", "ReplyId", "SecurityStamp", "TopicId" },
                values: new object[] { "70fd45ed-d565-43b1-81e3-9e6e2f0d768a", null, "322ed1bb-4a92-4db4-bcf5-750c34965bca", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac",
                columns: new[] { "ConcurrencyStamp", "ReplyId", "SecurityStamp", "TopicId" },
                values: new object[] { "46903730-26fb-404f-bd8c-53e822cd5005", null, "e480f9a3-5f20-4fd9-b0f0-f37eaeb1d327", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7",
                columns: new[] { "ConcurrencyStamp", "ReplyId", "SecurityStamp", "TopicId" },
                values: new object[] { "81a5c7a5-2e76-4aa3-b7ba-6a5dda53c91f", null, "a9535305-9b49-4678-9e9d-bad5e982cdc1", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReplyId",
                table: "AspNetUsers",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TopicId",
                table: "AspNetUsers",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Replys_ReplyId",
                table: "AspNetUsers",
                column: "ReplyId",
                principalTable: "Replys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_topic_TopicId",
                table: "AspNetUsers",
                column: "TopicId",
                principalTable: "tb_topic",
                principalColumn: "Id");
        }
    }
}
