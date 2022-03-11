using Microsoft.EntityFrameworkCore.Migrations;

namespace TargetApp.API.Migrations
{
    public partial class _11032022_1443_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyAppInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodicallyTimeForCheck = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAppInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyAppInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyAppHealths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyAppInfoId = table.Column<int>(type: "int", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyAppHealths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyAppHealths_MyAppInfos_MyAppInfoId",
                        column: x => x.MyAppInfoId,
                        principalTable: "MyAppInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MyAppHealthId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_MyAppHealths_MyAppHealthId",
                        column: x => x.MyAppHealthId,
                        principalTable: "MyAppHealths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyAppHealths_MyAppInfoId",
                table: "MyAppHealths",
                column: "MyAppInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MyAppInfos_UserId",
                table: "MyAppInfos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_MyAppHealthId",
                table: "Notification",
                column: "MyAppHealthId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "MyAppHealths");

            migrationBuilder.DropTable(
                name: "MyAppInfos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
