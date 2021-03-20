using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class updateFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Fornecedores",
                newName: "NomeFantasia");

            migrationBuilder.AlterColumn<string>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FornecedorAtivo",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeAtendente",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Fornecedores",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "FornecedorAtivo",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "NomeAtendente",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Fornecedores");

            migrationBuilder.RenameColumn(
                name: "NomeFantasia",
                table: "Fornecedores",
                newName: "Nome");

            migrationBuilder.AlterColumn<int>(
                name: "TipoFornecedor",
                table: "Fornecedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Fornecedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Fornecedores",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "");
        }
    }
}
