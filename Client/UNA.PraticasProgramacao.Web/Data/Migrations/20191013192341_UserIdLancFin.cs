using Microsoft.EntityFrameworkCore.Migrations;

namespace UNA.PraticasProgramacao.Web.Data.Migrations
{
    public partial class UserIdLancFin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LancamentoFinanceiro",
                type: "nvarchar(450)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LancamentoFinanceiro");


        }
    }
}
