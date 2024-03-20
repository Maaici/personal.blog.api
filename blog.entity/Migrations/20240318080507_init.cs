using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.entity.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OriginalPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalView = table.Column<int>(type: "int", nullable: false),
                    TotalLike = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Top = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usersLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "websiteInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebsiteName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDay = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SomeWords = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    photoPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BackgroungImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_websiteInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "usersLinks");

            migrationBuilder.DropTable(
                name: "websiteInfos");
        }
    }
}
