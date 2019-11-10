using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UNA.PraticasProgramacao.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCategoria = table.Column<string>(maxLength: 6, nullable: true),
                    DescricaoCategoria = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "CentroCusto",
                columns: table => new
                {
                    IdCentroCusto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCentroCusto = table.Column<string>(maxLength: 80, nullable: false),
                    Responsavel = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCusto", x => x.IdCentroCusto);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    IdContaBancaria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banco = table.Column<string>(maxLength: 15, nullable: false),
                    Agencia = table.Column<string>(maxLength: 6, nullable: false),
                    NumeroConta = table.Column<string>(maxLength: 20, nullable: false),
                    SaldoInicial = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.IdContaBancaria);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    IdFormaPagamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoFormaPagamento = table.Column<string>(maxLength: 80, nullable: true),
                    PrazoDias = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.IdFormaPagamento);
                });

            migrationBuilder.CreateTable(
                name: "ITS_MENU",
                columns: table => new
                {
                    IdMenu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMenu = table.Column<string>(maxLength: 300, nullable: true),
                    MenuPai = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    MenuText = table.Column<string>(maxLength: 500, nullable: true),
                    MenuType = table.Column<string>(maxLength: 50, nullable: true),
                    ControllerClass = table.Column<string>(nullable: true),
                    ActionController = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITS_MENU", x => x.IdMenu);
                });

            migrationBuilder.CreateTable(
                name: "Parceiro",
                columns: table => new
                {
                    IdParceiro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeParceiro = table.Column<string>(maxLength: 100, nullable: true),
                    TipoParceiro = table.Column<int>(nullable: false),
                    CpfCnpj = table.Column<string>(maxLength: 14, nullable: true),
                    NomeEndereco = table.Column<string>(maxLength: 100, nullable: true),
                    NumeroEndereco = table.Column<string>(maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(maxLength: 20, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Municipio = table.Column<string>(maxLength: 80, nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiro", x => x.IdParceiro);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimento",
                columns: table => new
                {
                    IdTipoMovimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoMovimento = table.Column<string>(maxLength: 50, nullable: true),
                    Observacoes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimento", x => x.IdTipoMovimento);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeMedida",
                columns: table => new
                {
                    IdUnidadeMedida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodUnidadeMedida = table.Column<string>(maxLength: 6, nullable: true),
                    NomeUnidadeMedida = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeMedida", x => x.IdUnidadeMedida);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "LancamentoFinanceiro",
                columns: table => new
                {
                    IdLancamentoFinanceiro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroLancamento = table.Column<string>(maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    IdCentroCusto = table.Column<int>(nullable: true),
                    TipoLancamento = table.Column<int>(nullable: false),
                    HistoricoLancamento = table.Column<string>(maxLength: 100, nullable: true),
                    ValorLancamento = table.Column<decimal>(nullable: true),
                    IdContaBancaria = table.Column<int>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: true),
                    IdParceiro = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoFinanceiro", x => x.IdLancamentoFinanceiro);
                    table.ForeignKey(
                        name: "FK_LancamentoFinanceiro_CentroCusto_IdCentroCusto",
                        column: x => x.IdCentroCusto,
                        principalTable: "CentroCusto",
                        principalColumn: "IdCentroCusto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentoFinanceiro_ContaBancaria_IdContaBancaria",
                        column: x => x.IdContaBancaria,
                        principalTable: "ContaBancaria",
                        principalColumn: "IdContaBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentoFinanceiro_Parceiro_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "Parceiro",
                        principalColumn: "IdParceiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentoFinanceiro_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    IdMovimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMovimento = table.Column<int>(nullable: true),
                    DataMovimento = table.Column<DateTime>(nullable: true),
                    IdParceiro = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(maxLength: 80, nullable: true),
                    ValorDesconto = table.Column<decimal>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: true),
                    IdFormaPagamento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.IdMovimento);
                    table.ForeignKey(
                        name: "FK_Movimento_FormaPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "IdFormaPagamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimento_Parceiro_IdParceiro",
                        column: x => x.IdParceiro,
                        principalTable: "Parceiro",
                        principalColumn: "IdParceiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimento_TipoMovimento_IdTipoMovimento",
                        column: x => x.IdTipoMovimento,
                        principalTable: "TipoMovimento",
                        principalColumn: "IdTipoMovimento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProduto = table.Column<string>(maxLength: 10, nullable: true),
                    DescricaoProduto = table.Column<string>(maxLength: 200, nullable: true),
                    Ncm = table.Column<string>(maxLength: 8, nullable: true),
                    IdUnidadeMedida = table.Column<int>(nullable: true),
                    IdCategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_CategoriaProduto_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaProduto",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_UnidadeMedida_IdUnidadeMedida",
                        column: x => x.IdUnidadeMedida,
                        principalTable: "UnidadeMedida",
                        principalColumn: "IdUnidadeMedida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemMovimento",
                columns: table => new
                {
                    IdItemMovimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovimento = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: true),
                    Quantidade = table.Column<decimal>(nullable: true),
                    ValorUnitario = table.Column<decimal>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: true),
                    ValorDesconto = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMovimento", x => x.IdItemMovimento);
                    table.ForeignKey(
                        name: "FK_ItemMovimento_Movimento_IdMovimento",
                        column: x => x.IdMovimento,
                        principalTable: "Movimento",
                        principalColumn: "IdMovimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMovimento_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovimento_IdMovimento",
                table: "ItemMovimento",
                column: "IdMovimento");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMovimento_IdProduto",
                table: "ItemMovimento",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoFinanceiro_IdCentroCusto",
                table: "LancamentoFinanceiro",
                column: "IdCentroCusto");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoFinanceiro_IdContaBancaria",
                table: "LancamentoFinanceiro",
                column: "IdContaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoFinanceiro_IdParceiro",
                table: "LancamentoFinanceiro",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoFinanceiro_UserId",
                table: "LancamentoFinanceiro",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdFormaPagamento",
                table: "Movimento",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdParceiro",
                table: "Movimento",
                column: "IdParceiro");

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdTipoMovimento",
                table: "Movimento",
                column: "IdTipoMovimento");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdUnidadeMedida",
                table: "Produtos",
                column: "IdUnidadeMedida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ItemMovimento");

            migrationBuilder.DropTable(
                name: "ITS_MENU");

            migrationBuilder.DropTable(
                name: "LancamentoFinanceiro");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "CentroCusto");

            migrationBuilder.DropTable(
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Parceiro");

            migrationBuilder.DropTable(
                name: "TipoMovimento");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");

            migrationBuilder.DropTable(
                name: "UnidadeMedida");
        }
    }
}
