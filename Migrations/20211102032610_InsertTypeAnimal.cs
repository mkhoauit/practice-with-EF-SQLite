using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class InsertTypeAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Animals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Speak = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Animals");
        }
    }
}
