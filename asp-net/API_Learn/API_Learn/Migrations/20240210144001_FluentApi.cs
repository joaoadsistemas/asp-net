using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSLearn.Migrations
{
    /// <inheritdoc />
    public partial class FluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgGrayUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartMoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndMoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_offer_tb_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tb_course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_resource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    imgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExternalLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_resource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_resource_tb_offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "tb_offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreRequisiteId = table.Column<int>(type: "int", nullable: true),
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_section_tb_resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "tb_resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_section_tb_section_PreRequisiteId",
                        column: x => x.PreRequisiteId,
                        principalTable: "tb_section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_lesson_tb_section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tb_section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TextContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_content_tb_lesson_Id",
                        column: x => x.Id,
                        principalTable: "tb_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionCount = table.Column<int>(type: "int", nullable: false),
                    ApprovalCount = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DueMoment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_task_tb_lesson_Id",
                        column: x => x.Id,
                        principalTable: "tb_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyId = table.Column<int>(type: "int", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_enrollment",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnrollMoment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefoundMoment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avaiable = table.Column<bool>(type: "bit", nullable: false),
                    OnlyUpdate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_enrollment", x => new { x.OfferId, x.UserId });
                    table.ForeignKey(
                        name: "FK_tb_enrollment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_enrollment_tb_offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "tb_offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_notification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentLesson",
                columns: table => new
                {
                    LessonsDoneId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentsDoneOfferId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentsDoneUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentLesson", x => new { x.LessonsDoneId, x.EnrollmentsDoneOfferId, x.EnrollmentsDoneUserId });
                    table.ForeignKey(
                        name: "FK_EnrollmentLesson_tb_enrollment_EnrollmentsDoneOfferId_EnrollmentsDoneUserId",
                        columns: x => new { x.EnrollmentsDoneOfferId, x.EnrollmentsDoneUserId },
                        principalTable: "tb_enrollment",
                        principalColumns: new[] { "OfferId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentLesson_tb_lesson_LessonsDoneId",
                        column: x => x.LessonsDoneId,
                        principalTable: "tb_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_deliver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectCount = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentOfferId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_deliver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_deliver_tb_enrollment_EnrollmentOfferId_EnrollmentUserId",
                        columns: x => new { x.EnrollmentOfferId, x.EnrollmentUserId },
                        principalTable: "tb_enrollment",
                        principalColumns: new[] { "OfferId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_deliver_tb_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "tb_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replys_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReplyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_topic_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_topic_Replys_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_topic_tb_lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "tb_lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_topic_tb_offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "tb_offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReplyId",
                table: "AspNetUsers",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TopicId",
                table: "AspNetUsers",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentLesson_EnrollmentsDoneOfferId_EnrollmentsDoneUserId",
                table: "EnrollmentLesson",
                columns: new[] { "EnrollmentsDoneOfferId", "EnrollmentsDoneUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Replys_AuthorId",
                table: "Replys",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Replys_TopicId",
                table: "Replys",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_deliver_EnrollmentOfferId_EnrollmentUserId",
                table: "tb_deliver",
                columns: new[] { "EnrollmentOfferId", "EnrollmentUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_deliver_LessonId",
                table: "tb_deliver",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_enrollment_UserId",
                table: "tb_enrollment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lesson_SectionId",
                table: "tb_lesson",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_notification_UserId",
                table: "tb_notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_offer_CourseId",
                table: "tb_offer",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_resource_OfferId",
                table: "tb_resource",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_section_PreRequisiteId",
                table: "tb_section",
                column: "PreRequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_section_ResourceId",
                table: "tb_section",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_topic_AuthorId",
                table: "tb_topic",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_topic_LessonId",
                table: "tb_topic",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_topic_OfferId",
                table: "tb_topic",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_topic_ReplyId",
                table: "tb_topic",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Replys_tb_topic_TopicId",
                table: "Replys",
                column: "TopicId",
                principalTable: "tb_topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replys_AspNetUsers_AuthorId",
                table: "Replys");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_topic_AspNetUsers_AuthorId",
                table: "tb_topic");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_topic_Replys_ReplyId",
                table: "tb_topic");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EnrollmentLesson");

            migrationBuilder.DropTable(
                name: "tb_content");

            migrationBuilder.DropTable(
                name: "tb_deliver");

            migrationBuilder.DropTable(
                name: "tb_notification");

            migrationBuilder.DropTable(
                name: "tb_task");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tb_enrollment");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Replys");

            migrationBuilder.DropTable(
                name: "tb_topic");

            migrationBuilder.DropTable(
                name: "tb_lesson");

            migrationBuilder.DropTable(
                name: "tb_section");

            migrationBuilder.DropTable(
                name: "tb_resource");

            migrationBuilder.DropTable(
                name: "tb_offer");

            migrationBuilder.DropTable(
                name: "tb_course");
        }
    }
}
