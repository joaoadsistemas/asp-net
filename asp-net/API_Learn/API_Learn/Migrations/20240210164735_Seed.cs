using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DSLearn.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_deliver_tb_enrollment_EnrollmentOfferId_EnrollmentUserId",
                table: "tb_deliver");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "tb_deliver");

            migrationBuilder.RenameColumn(
                name: "EnrollmentUserId",
                table: "tb_deliver",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EnrollmentOfferId",
                table: "tb_deliver",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_deliver_EnrollmentOfferId_EnrollmentUserId",
                table: "tb_deliver",
                newName: "IX_tb_deliver_OfferId_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "tb_deliver",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "ROLE_STUDENT", "ROLE_STUDENT" },
                    { "2", null, "ROLE_INSTRUCTOR", "ROLE_INSTRUCTOR" },
                    { "3", null, "ROLE_ADMIN", "ROLE_ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "ReplyId", "SecurityStamp", "TopicId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b01910b-4e21-4cf3-a859-9a79261d0385", 0, "e232e65c-6eaf-4bec-a670-03f79bdae734", "alex@gmail.com", false, false, null, null, null, "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "9495a870-3954-443c-a81e-b2ac3752bd7c", null, false, "Alex Brown" },
                    { "a1ff4f6c-5011-4b95-9bda-2bc33693fcac", 0, "76d7e625-f131-44d2-b4ed-ee813f94fb23", "maria@gmail.com", false, false, null, null, null, "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "5376244a-3a4c-42bc-98cc-199c06dbd64c", null, false, "Maria Green" },
                    { "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", 0, "39a4c971-c582-4747-953c-c04259324c79", "bob@gmail.com", false, false, null, null, null, "$2a$10$eACCYoNOHEqXve8aIWT8Nu3PkMXWBaOxJ9aORUYzfMQCbVBIhZ8tG", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "b1703405-4fce-4b02-96e2-e71a5a92781f", null, false, "Bob Brown" }
                });

            migrationBuilder.InsertData(
                table: "tb_course",
                columns: new[] { "Id", "ImgGrayUri", "ImgUri", "Name" },
                values: new object[] { 1, "https://upload.wikimedia.org/wikipedia/commons/1/1f/Switch-course-book-grey.svg", "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg", "Bootcamp HTML" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "3b01910b-4e21-4cf3-a859-9a79261d0385" },
                    { "1", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" },
                    { "2", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" },
                    { "3", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" },
                    { "1", "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7" },
                    { "2", "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7" }
                });

            migrationBuilder.InsertData(
                table: "tb_notification",
                columns: new[] { "Id", "Moment", "Read", "Route", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), true, "/offers/1/resource/1/sections/1", "Primeiro feedback de tarefa: favor revisar", "3b01910b-4e21-4cf3-a859-9a79261d0385" },
                    { 2, new DateTime(2020, 12, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), true, "/offers/1/resource/1/sections/1", "Segundo feedback: favor revisar", "3b01910b-4e21-4cf3-a859-9a79261d0385" },
                    { 3, new DateTime(2020, 12, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), true, "/offers/1/resource/1/sections/1", "Terceiro feedback: favor revisar", "3b01910b-4e21-4cf3-a859-9a79261d0385" }
                });

            migrationBuilder.InsertData(
                table: "tb_offer",
                columns: new[] { "Id", "CourseId", "Edition", "EndMoment", "StartMoment" },
                values: new object[,]
                {
                    { 1, 1, "1.0", new DateTime(2021, 11, 20, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "2.0", new DateTime(2021, 12, 20, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tb_enrollment",
                columns: new[] { "OfferId", "UserId", "Available", "EnrollMoment", "OnlyUpdate", "RefundMoment" },
                values: new object[,]
                {
                    { 1, "3b01910b-4e21-4cf3-a859-9a79261d0385", true, new DateTime(2020, 11, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { 2, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", true, new DateTime(2020, 11, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), false, null }
                });

            migrationBuilder.InsertData(
                table: "tb_resource",
                columns: new[] { "Id", "Description", "ExternalLink", "OfferId", "Position", "Title", "Type", "imgUri" },
                values: new object[,]
                {
                    { 1, "Trilha principal do curso", null, 1, 1, "Trilha HTML", 1, "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg" },
                    { 2, "Tire suas dúvidas", null, 1, 2, "Forum", 2, "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg" },
                    { 3, "Lives exclusivas para a turma", null, 1, 3, "Lives", 0, "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg" }
                });

            migrationBuilder.InsertData(
                table: "tb_section",
                columns: new[] { "Id", "Description", "ImgUri", "Position", "PreRequisiteId", "ResourceId", "Title" },
                values: new object[] { 1, "Neste capítulo vamos começar", "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg", 1, null, 1, "Capítulo 1" });

            migrationBuilder.InsertData(
                table: "tb_lesson",
                columns: new[] { "Id", "Position", "SectionId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Aula 1 do capítulo 1" },
                    { 2, 2, 1, "Aula 2 do capítulo 1" },
                    { 3, 3, 1, "Aula 3 do capítulo 1" },
                    { 4, 4, 1, "Tarefa do capítulo 1" }
                });

            migrationBuilder.InsertData(
                table: "tb_section",
                columns: new[] { "Id", "Description", "ImgUri", "Position", "PreRequisiteId", "ResourceId", "Title" },
                values: new object[] { 2, "Neste capítulo vamos continuar", "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg", 2, 1, 1, "Capítulo 2" });

            migrationBuilder.InsertData(
                table: "tb_content",
                columns: new[] { "Id", "TextContent", "VideoUri" },
                values: new object[,]
                {
                    { 1, "Material de apoio: abc", "https://www.youtube.com/watch?v=sqbqoR-lMf8" },
                    { 2, "", "https://www.youtube.com/watch?v=sqbqoR-lMf8" },
                    { 3, "", "https://www.youtube.com/watch?v=sqbqoR-lMf8" }
                });

            migrationBuilder.InsertData(
                table: "tb_deliver",
                columns: new[] { "Id", "CorrectCount", "Feedback", "LessonId", "Moment", "OfferId", "Status", "Uri", "UserId" },
                values: new object[] { 1, null, null, 4, new DateTime(2020, 12, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "https://github.com/devsuperior/bds-dslearn", "3b01910b-4e21-4cf3-a859-9a79261d0385" });

            migrationBuilder.InsertData(
                table: "tb_section",
                columns: new[] { "Id", "Description", "ImgUri", "Position", "PreRequisiteId", "ResourceId", "Title" },
                values: new object[] { 3, "Neste capítulo vamos finalizar", "https://cdn.pixabay.com/photo/2018/03/22/10/55/training-course-3250007_1280.jpg", 3, 2, 1, "Capítulo 3" });

            migrationBuilder.InsertData(
                table: "tb_task",
                columns: new[] { "Id", "ApprovalCount", "Description", "DueMoment", "QuestionCount", "Weight" },
                values: new object[] { 4, 4, "Fazer um trabalho legal", new DateTime(2020, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 1.0 });

            migrationBuilder.InsertData(
                table: "tb_topic",
                columns: new[] { "Id", "AuthorId", "Body", "LessonId", "Moment", "OfferId", "ReplyId", "Title" },
                values: new object[,]
                {
                    { 1, "3b01910b-4e21-4cf3-a859-9a79261d0385", "Corpo do tópico 1", 1, new DateTime(2020, 12, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 1" },
                    { 2, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", "Corpo do tópico 2", 1, new DateTime(2020, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 2" },
                    { 3, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", "Corpo do tópico 3", 1, new DateTime(2020, 12, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 3" },
                    { 4, "3b01910b-4e21-4cf3-a859-9a79261d0385", "Corpo do tópico 4", 2, new DateTime(2020, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 4" },
                    { 5, "3b01910b-4e21-4cf3-a859-9a79261d0385", "Corpo do tópico 5", 2, new DateTime(2020, 12, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 5" },
                    { 6, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", "Corpo do tópico 6", 3, new DateTime(2020, 12, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Título do tópico 6" }
                });

            migrationBuilder.InsertData(
                table: "Replys",
                columns: new[] { "Id", "AuthorId", "Body", "Moment", "TopicId" },
                values: new object[,]
                {
                    { 1, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7", "Tente reiniciar o computador", new DateTime(2020, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "3b01910b-4e21-4cf3-a859-9a79261d0385", "Deu certo, valeu!", new DateTime(2020, 12, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_deliver_tb_enrollment_OfferId_UserId",
                table: "tb_deliver",
                columns: new[] { "OfferId", "UserId" },
                principalTable: "tb_enrollment",
                principalColumns: new[] { "OfferId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_deliver_tb_enrollment_OfferId_UserId",
                table: "tb_deliver");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "3b01910b-4e21-4cf3-a859-9a79261d0385" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "a1ff4f6c-5011-4b95-9bda-2bc33693fcac" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7" });

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Replys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_content",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_content",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_content",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_deliver",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_enrollment",
                keyColumns: new[] { "OfferId", "UserId" },
                keyValues: new object[] { 2, "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7" });

            migrationBuilder.DeleteData(
                table: "tb_notification",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_notification",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_notification",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_resource",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_resource",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_section",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_task",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1ff4f6c-5011-4b95-9bda-2bc33693fcac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc8cf0a3-c3d2-49d2-8d20-1e22a6c4b8a7");

            migrationBuilder.DeleteData(
                table: "tb_enrollment",
                keyColumns: new[] { "OfferId", "UserId" },
                keyValues: new object[] { 1, "3b01910b-4e21-4cf3-a859-9a79261d0385" });

            migrationBuilder.DeleteData(
                table: "tb_lesson",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_lesson",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tb_lesson",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tb_offer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_section",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tb_topic",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b01910b-4e21-4cf3-a859-9a79261d0385");

            migrationBuilder.DeleteData(
                table: "tb_lesson",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_section",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_resource",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_offer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tb_course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "tb_deliver",
                newName: "EnrollmentUserId");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "tb_deliver",
                newName: "EnrollmentOfferId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_deliver_OfferId_UserId",
                table: "tb_deliver",
                newName: "IX_tb_deliver_EnrollmentOfferId_EnrollmentUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Feedback",
                table: "tb_deliver",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "tb_deliver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_deliver_tb_enrollment_EnrollmentOfferId_EnrollmentUserId",
                table: "tb_deliver",
                columns: new[] { "EnrollmentOfferId", "EnrollmentUserId" },
                principalTable: "tb_enrollment",
                principalColumns: new[] { "OfferId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
