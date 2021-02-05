using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace xXxYeetroom2000xXx.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forumeinträge",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Verfasser = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Eintrag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forumeinträge", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kommentar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Post_ID = table.Column<int>(nullable: false),
                    Verfasser = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Eintrag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentar", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forumeinträge");

            migrationBuilder.DropTable(
                name: "Kommentar");
        }
    }
}
