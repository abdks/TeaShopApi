using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShopApiDataAccessLayer.Migrations
{
    public partial class mig_add_t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.RenameTable(
                name: "Drinks",
                newName: "drinks");

            migrationBuilder.RenameColumn(
                name: "DrinkPrice",
                table: "drinks",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "DrinkName",
                table: "drinks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "DrinkImageUrl",
                table: "drinks",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DrinkID",
                table: "drinks",
                newName: "DrinksID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "drinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drinks",
                table: "drinks",
                column: "DrinksID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_drinks",
                table: "drinks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "drinks");

            migrationBuilder.RenameTable(
                name: "drinks",
                newName: "Drinks");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Drinks",
                newName: "DrinkName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Drinks",
                newName: "DrinkPrice");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Drinks",
                newName: "DrinkImageUrl");

            migrationBuilder.RenameColumn(
                name: "DrinksID",
                table: "Drinks",
                newName: "DrinkID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                column: "DrinkID");

            migrationBuilder.CreateTable(
                name: "drinks",
                columns: table => new
                {
                    DrinksID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinks", x => x.DrinksID);
                });
        }
    }
}
