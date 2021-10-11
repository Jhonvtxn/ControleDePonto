using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class add_Dashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dasboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Workload = table.Column<int>(type: "varchar(100)", nullable: false),
                    Balance = table.Column<double>(type: "varchar(20)", nullable: false),
                    CollaboratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dasboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dasboard_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dasboard_CollaboratorId",
                table: "Dasboard",
                column: "CollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dasboard");
        }
    }
}
