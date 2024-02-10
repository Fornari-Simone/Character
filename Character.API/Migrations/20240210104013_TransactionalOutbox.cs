using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Character.API.Migrations
{
    /// <inheritdoc />
    public partial class TransactionalOutbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransitionalOutboxes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabella = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messaggio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitionalOutboxes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransitionalOutboxes");
        }
    }
}
