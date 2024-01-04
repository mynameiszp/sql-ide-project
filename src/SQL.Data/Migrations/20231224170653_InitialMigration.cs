using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SQL.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatabaseEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    DateOfCreation = table.Column<DateOnly>(type: "date", nullable: false),
                    DBType = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchemeEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    DatabaseEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemeEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchemeEntities_DatabaseEntities_DatabaseEntityId",
                        column: x => x.DatabaseEntityId,
                        principalTable: "DatabaseEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TableEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    SchemeEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableEntities_SchemeEntities_SchemeEntityId",
                        column: x => x.SchemeEntityId,
                        principalTable: "SchemeEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ColumnEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    TableEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnEntities_TableEntities_TableEntityId",
                        column: x => x.TableEntityId,
                        principalTable: "TableEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnEntities_TableEntityId",
                table: "ColumnEntities",
                column: "TableEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchemeEntities_DatabaseEntityId",
                table: "SchemeEntities",
                column: "DatabaseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TableEntities_SchemeEntityId",
                table: "TableEntities",
                column: "SchemeEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnEntities");

            migrationBuilder.DropTable(
                name: "TableEntities");

            migrationBuilder.DropTable(
                name: "SchemeEntities");

            migrationBuilder.DropTable(
                name: "DatabaseEntities");
        }
    }
}
